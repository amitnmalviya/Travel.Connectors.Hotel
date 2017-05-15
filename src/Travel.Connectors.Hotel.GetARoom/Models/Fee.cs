using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class Fee
    {
        public string name { get; set; }
        public double amount { get; set; }
        public double total { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
    }
}
