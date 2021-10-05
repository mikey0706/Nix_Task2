using DataLayer.Models;
using System;

namespace DataLayer
{
    public class Context
    {
        public XmlSet<Visitor> Visitors = new XmlSet<Visitor>();
        public XmlSet<Room> Rooms = new XmlSet<Room>();

        public Context() {
            if(!Visitors.Exists & !Rooms.Exists)
            Initialization();
        }

        //Инициализация
        private void Initialization() 
        {
            var room1 = new Room
            {
                Id = 1,
                RoomNumber = 1,
                RoomType = "Technical room",
                PricePerNight = 20,
                CheckIn = new DateTime(2021, 10, 01).ToShortDateString(),
                CheckOut = new DateTime(2041, 10, 01).ToShortDateString()
            };
            var room2 = new Room
            {
                Id = 2,
                RoomNumber = 2,
                RoomType = "Lux",
                PricePerNight = 20,
                CheckIn = new DateTime(2021, 10, 01).ToShortDateString(),
                CheckOut = new DateTime(2021, 10, 20).ToShortDateString()
            };
            
            var admin = new Visitor
            {
                Id = 1,
                Name = "Admin",
                Passport = "Multipassport",
                MyRoomId = 1,
                DateOfBirth = DateTime.Now.Date.ToShortDateString()

            };
            var stuff = new Visitor
            {
                Id = 2,
                Name = "John",
                Passport = "653456356",
                MyRoomId = 2,
                DateOfBirth = DateTime.Now.Date.ToShortDateString()

            };
            room1.VisitorId = 1;
            room2.VisitorId = 2;


            Rooms.Add(room1);
            Rooms.Add(room2);
            Visitors.Add(admin);
            Visitors.Add(stuff);

        }
    }
}
