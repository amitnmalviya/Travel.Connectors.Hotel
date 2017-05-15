using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class RoomOption
    {
        public string refId { get; set; }
        public string code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string roomTypeCode { get; set; }
        public string name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string desc { get; set; }
        public int? availableRooms { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<BedDetail> bedDetails { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? maxOcccupancy { get; set; }
        public string smokingPreference { get; set; }
    }
}
