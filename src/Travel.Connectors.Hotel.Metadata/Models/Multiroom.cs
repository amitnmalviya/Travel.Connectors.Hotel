using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class Multiroom
    {
        public bool supported { get; set; }
        public int maxRoomsPerBooking { get; set; }
        public int maxGuestsPerRoom { get; set; }
        public string fareType { get; set; }
        public string allowDifferentOccupancies { get; set; }
        public string cancellationType { get; set; }
    }
}
