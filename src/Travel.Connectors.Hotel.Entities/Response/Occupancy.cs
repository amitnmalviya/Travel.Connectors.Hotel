using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Occupancy
    {
        public string refId { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
    }
}
