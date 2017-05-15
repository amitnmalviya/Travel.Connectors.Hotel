using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class RoomRate
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PerRoomRates[] perRoomRates { get; set; }
        public List<PerBookingRates> perBookingRates { get; set; }
    }
}
