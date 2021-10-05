using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public int VisitorId { get; set; }

        public int PricePerNight { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }
    }
}
