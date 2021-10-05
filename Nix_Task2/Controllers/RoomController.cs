using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessLayer;
using AutoMapper;
using Nix_Task2.ViewModels;
using BusinessLayer.DTO;

namespace Nix_Task2.Controllers
{
    public class RoomController
    {
        private readonly UnitOfWork _unit;
        private readonly List<RoomView> rooms;
        private IMapper mapper = new Mapper(AutomapperConfig.Config);

        public RoomController() 
        {
            _unit = new UnitOfWork();
            var r = _unit.RoomsData().AllRooms();
            rooms = mapper.Map<List<RoomDTO>, List<RoomView>>(r);
        }

        public void RoomsInfo() 
        {
            foreach (var item in rooms) 
            {
                Console.WriteLine($"Номер комнаты:{item.RoomNumber}\n Цена за ночь: {item.PricePerNight}\n " +
                    $"Категория комнаты: {item.RoomType}");
            }
        }

        public List<RoomView> VacantRoom(string date) 
        {
            var d = DateTime.Parse(date);
            return rooms.Where(r => DateTime.Parse(r.CheckOut).Date < d.Date).ToList();
        }

        public void AddRoom(RoomView room) 
        {
            if (rooms.Exists(r => r.RoomNumber == room.RoomNumber)) 
            {
                Console.WriteLine("Такой номер уже существует");
                return;
            }
            room.Id = ++rooms.Last().Id;
            room.RoomNumber = room.Id;
            _unit.RoomsData().AddRoom(mapper.Map<RoomDTO>(room));
        }

        public string EditRoom(RoomView room) 
        {
            return _unit.RoomsData().EditRoom(mapper.Map<RoomDTO>(room));
        }

        public string DeleteRoom(int number) 
        {
            return _unit.RoomsData().DeleteRoom(number);
        }
    }
}
