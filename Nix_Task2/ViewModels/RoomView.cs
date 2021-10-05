using System;
using System.Collections.Generic;
using System.Text;

namespace Nix_Task2.ViewModels
{
    public class RoomView
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public int VisitorId { get; set; }

        public int PricePerNight { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public RoomView()
        {
            RoomType = "Undefined";
            VisitorId = 0;
            PricePerNight = 0;
            CheckIn = DateTime.MinValue.Date.ToShortDateString();
            CheckOut = DateTime.MinValue.Date.ToShortDateString();
        }
    }
}
