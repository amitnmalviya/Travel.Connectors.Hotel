using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class NightlyRate
    {
        public DateTime perNightDate { get; set; }
        [XmlElement("date")]
        // this redundant property has been added to de-seriliaze perNightDate property when it's null is xml resposne  
        public string PerNightDate
        {
            get
            {
                return perNightDate.ToString(ApplicationConstants.dateFormat);
            }
            set
            {
                perNightDate = DateTime.Parse(value);
            }
        }

        public double rate { get; set; }

        public double originalrate { get; set; }
        [XmlElement("original-rate")]
        public string OriginalrRate
        {
            get
            {
                return originalrate.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    originalrate = double.Parse(value);
            }
        }
    }
}
