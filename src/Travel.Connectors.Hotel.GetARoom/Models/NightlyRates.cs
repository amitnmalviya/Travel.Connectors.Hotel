using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class NightlyRates
    {
        [XmlElement("nightly-rate")]
        public NightlyRate[] nightlyrate { get; set; }
    }
}
