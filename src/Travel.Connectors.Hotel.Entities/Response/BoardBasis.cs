using System;
using System.Linq;

namespace Travel.Connectors.Hotel.Entities
{
    public class BoardBasis
    {
        public string code { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public double amount { get; set; }
        public bool amountIncludedInRate { get; set; }
    }
}
