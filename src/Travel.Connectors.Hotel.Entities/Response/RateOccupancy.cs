using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class RateOccupancy
    {
        public string refId { get; set; }
        public string roomRefId { get; set; }
        public string occupancyRefId { get; set; }
    }
}
