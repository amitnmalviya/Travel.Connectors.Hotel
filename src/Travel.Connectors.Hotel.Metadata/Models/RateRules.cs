using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class RateRules
    {
        public bool rateCodeAllowed { get; set; }
        public string cancellationPolicyFormat { get; set; }
        public string[] optionalData { get; set; }
        public string[] requestOptions { get; set; }
        public bool guaranteeRequired { get; set; }
        public bool depositRequired { get; set; }
        public bool refundablity { get; set; }
        public CreditCardInfo creditCardInfo { get; set; }
        public string allPaxRequiredForBooking { get; set; }

    }
}
