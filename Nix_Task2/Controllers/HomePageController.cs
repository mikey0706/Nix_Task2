using AutoMapper;
using BusinessLayer;
using BusinessLayer.DTO;
using Nix_Task2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nix_Task2.Controllers
{
    public class HomePageController
    {
        private readonly UnitOfWork _unit;
        private readonly List<VisitorView> visitors;
        private readonly List<RoomView> rooms;
        private IMapper mapper = new Mapper(AutomapperConfig.Config);

        public HomePageController() 
        {
            _unit = new UnitOfWork();
            var v = _unit.VisitorData().AllVisitors();
            var r = _unit.RoomsData().AllRooms();
            visitors = mapper.Map<List<VisitorDTO>, List<VisitorView>>(v);
            rooms = mapper.Map<List<RoomDTO>, List<RoomView>>(r);
        }

        //Информация о заселении
        public void RoomsVisitorsInfo() 
        {
            List<BookedRooms> lst = rooms.Where(rm=>rm.VisitorId>0).Select(r=> new BookedRooms 
            { 
            Visitor = visitors.FirstOrDefault(v=>v.Id == r.VisitorId),
            Room = r
            }).ToList();

            foreach (var item in lst)
            {
                Console.WriteLine($"Комната: {item.Room.RoomNumber} - Имя жильца: {item.Visitor.Name}");
            }
        }

        //Бронирование комнаты
        public void BookRoom(int userId, int roomNum, string checkIn, string checkOut) 
        {
            var visitor = visitors.FirstOrDefault(v=>v.Id==userId);
            var room = rooms.FirstOrDefault(r=>r.RoomNumber == roomNum);

            if (visitor != null & room != null)
            {
                room.VisitorId = visitor.Id;
                room.CheckIn = checkIn;
                room.CheckOut = checkOut;

                visitor.MyRoomId = room.Id;

                Console.WriteLine(_unit.VisitorData().EditVisitor(mapper.Map<VisitorDTO>(visitor)));
                Console.WriteLine(_unit.RoomsData().EditRoom(mapper.Map<RoomDTO>(room)));
            }
            else 
            {
                Console.WriteLine("Пользователь или комната не были найдены!");
            }

        }
    }
}
