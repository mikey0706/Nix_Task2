using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repositories
{
    public interface IRooms
    {
        public List<RoomDTO> AllRooms();
        public string EditRoom(RoomDTO visitor);
        public string DeleteRoom(int id);
        public void AddRoom(RoomDTO visitor);
    }
}
