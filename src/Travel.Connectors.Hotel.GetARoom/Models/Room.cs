using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class Room
    {
        [XmlElement("hotel-id")]
        public string hotelid { get; set; }
        [XmlElement("room-id")]
        public string roomid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
