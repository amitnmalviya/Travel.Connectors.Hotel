using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class TaxesAndFees
    {
        public double amount { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string desc { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string code { get; set; }
        public bool isIncludedInBase { get; set; }
    }
}
