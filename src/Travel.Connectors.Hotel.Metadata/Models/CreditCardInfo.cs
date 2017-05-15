using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class CreditCardInfo
    {
        public bool rateSpecific { get; set; }
        public string[] vendors { get; set; }
    }
}
