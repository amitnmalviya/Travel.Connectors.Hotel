using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class DailyRoomRates
    {
        public bool taxIncluded { get; set; }
        public Roombreakup[] breakup { get; set; }
    }
}
