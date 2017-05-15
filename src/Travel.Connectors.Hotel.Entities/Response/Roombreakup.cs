using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Roombreakup
    {
        public DateTime date { get; set; }
        public double amount { get; set; }
        public double discount { get; set; }
    }
}
