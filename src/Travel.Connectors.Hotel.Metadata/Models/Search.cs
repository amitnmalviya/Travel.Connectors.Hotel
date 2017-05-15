using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class Search
    {
        public string[] patterns { get; set; }
        public int maxHotelsSupported { get; set; }
        public string  maxRadiusKmAllowed { get; set; }
        public int maxRateCodesAllowed { get; set; }
        public string[] optionalData { get; set; }
        public int maxAllowedChildAge { get; set; }
        public string advanceBookingLimit { get; set; }
        public bool sameDayBookingAllowed { get; set; }
        public int maxStay { get; set; }
        public string[] requestOptions { get; set; }
    }
}
