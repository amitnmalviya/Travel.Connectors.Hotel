using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class Verbs
    {
        public Search search { get; set; }
        public RoomRates roomRates { get; set; }
        public RateRules rateRules { get; set; }
        public Book book { get; set; }
        public Cancel cancel { get; set; }
        public GetBookings getBookings { get; set; }

    }
}
