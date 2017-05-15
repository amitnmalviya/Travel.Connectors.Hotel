using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class RoomRates
    {
        public int maxRateCodesAllowed { get; set; }
        public string[] optionalData { get; set; }
        public string[] requestOptions { get; set; }
        public bool statelessSupported { get; set; }
    }
}
