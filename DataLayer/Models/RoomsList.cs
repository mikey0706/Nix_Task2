using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataLayer.Models
{
    //Сериализуем корневой элемент файла для класса Room в виде списка
    [Serializable, XmlRoot(ElementName = "ArrayOfRoom")]
    public class RoomsList
    {
        [XmlArray("rooms")]
        [XmlArrayItem("room")]
        public List<Room> Rooms { get; set; }

        public RoomsList() 
        {
            Rooms = new List<Room>();
        }
    }
}
