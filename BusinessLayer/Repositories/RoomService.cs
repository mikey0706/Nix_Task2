using AutoMapper;
using BusinessLayer.DTO;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repositories
{
    class RoomService : IRooms
    {
        private readonly Context _context;
        private IMapper mapper = new Mapper(AutomapperConfig.Config);

        public RoomService(Context context) 
        {
            _context = context;
        }
        public List<RoomDTO> AllRooms()
        {
            return mapper.Map<List<Room>, List<RoomDTO>>(_context.Rooms.Data);
        }
        public string EditRoom(RoomDTO room)
        {
            var v = AllRooms().Find(v => v.Id == room.Id);
            if (v != null)
            {
                string[] info = {
                room.Id.ToString(),
                room.RoomNumber.ToString(),
                room.RoomType,
                room.VisitorId.ToString(),
                room.PricePerNight.ToString(),
                room.CheckIn,
                room.CheckOut
            };

                _context.Rooms.EditNode(info);

                return "Данные успешно изменены!";
            }
            return "Комната не найдена!";
        }

        public string DeleteRoom(int id)
        {
            var v = AllRooms().Find(v => v.Id == id);
            if (v != null)
            {
                _context.Rooms.Remove(id);
                return $"Комната {v.RoomNumber} был удалена.";
            }
            return "Комната либо удалена, либо не существует.";
        }

        public void AddRoom(RoomDTO room)
        {
            _context.Rooms.Add(mapper.Map<Room>(room));
        }

    }
}
