using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Breakup
    {
        public double baseRate { get; set; }
        public TaxesAndFees[] taxesAndFees { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Discount discount { get; set; }
    }
}
