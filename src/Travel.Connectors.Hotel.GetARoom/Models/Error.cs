using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class Error
    {
        [XmlAttribute(AttributeName = "code")]
        public string code { get; set; }
        [XmlAttribute(AttributeName = "message")]
        public string message { get; set; }
    }
}
