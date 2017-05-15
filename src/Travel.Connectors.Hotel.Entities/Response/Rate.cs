using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Rate
    {
        public string currency { get; set; }
        public double minDailyRate { get; set; }
        public string[] inventoryTypes { get; set; }
    }
}
