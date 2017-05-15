using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    [XmlRoot("room-stays")]
    public class GetARoomSearchResponse
    {
        [XmlAttribute("transaction-id")]
        public string transactionid { get; set; }
        public Request request { get; set; }

        public Status status { get; set; }

        [XmlElement("room-stay")]
        public List<RoomStay> roomstay { get; set; }
    }
}
