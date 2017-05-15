using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Offer
    {
        public string title { get; set; }
        public string desc { get; set; }
        public double discountAmount { get; set; }
        public DiscountPercentage discountPercentage { get; set; }
        public PayStay payStay { get; set; }
    }
}
