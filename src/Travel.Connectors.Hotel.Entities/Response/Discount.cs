using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Discount
    {
        public double amount { get; set; }
        public string desc { get; set; }
        public bool isIncludedInBase { get; set; }
    }
}
