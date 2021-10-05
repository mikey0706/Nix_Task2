using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataLayer.Models
{
    [Serializable]
    public class Room 
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("RoomNumber")]
        public int RoomNumber { get; set; }

        [XmlElement("RoomType")]
        public string RoomType { get; set; }

        [XmlElement("Visitor")]
        public int VisitorId { get; set; }

        [XmlElement("PricePerNight")]
        public int PricePerNight { get; set; }

        [XmlElement("CheckIn")]
        public string CheckIn { get; set; }

        [XmlElement("CheckOut")]
        public string CheckOut { get; set; }

    }
}
