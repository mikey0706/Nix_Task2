using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataLayer.Models
{
    [Serializable]
    public class Visitor  
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Passport")]
        public string Passport { get; set; }

        [XmlElement("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [XmlElement("MyRoom")]
        public int MyRoomId { get; set; }

    }
}
