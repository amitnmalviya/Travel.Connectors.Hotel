using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class DisplayPricing
    {
        public double original_average { get; set; }
        [XmlElement("original-average")]
        public string originalaverage
        {
            get
            {
                return original_average.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    original_average = double.Parse(value);
            }
        }

        public double subtotal { get; set; }

        public double taxes { get; set; }

        public double fees { get; set; }

        public double total { get; set; }

        public double lowestaverage { get; set; }
        [XmlElement("lowest-average")]
        public string LowestAverage
        {
            get
            {
                return lowestaverage.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    lowestaverage = double.Parse(value);
            }

        }

        public string currency { get; set; }
        [XmlElement("nightly-rates")]
        public NightlyRates nightlyrates { get; set; }
    }
}
