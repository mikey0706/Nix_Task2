using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataLayer.Models
{
   //Сериализуем корневой элемент файла для класса Visitor в виде списка

   [Serializable, XmlRoot(ElementName = "ArrayOfVisitor")]
   public class VisitorsList
    {
        [XmlArray("visistors")]
        [XmlArrayItem("visitor")]
        public List<Visitor> Visitors { get; set; }

        public VisitorsList() 
        {
            Visitors = new List<Visitor>();
        }
    }
}
