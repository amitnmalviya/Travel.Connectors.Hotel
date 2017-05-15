using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class CancellationPenalty
    {
        public DateTime DeadlineDateTime { get; set; }
        [XmlElement("deadline")]
        public string Deadline
        {
            get
            {
                return DeadlineDateTime.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    DeadlineDateTime = DateTime.Parse(value);
            }
        }

        public double amount { get; set; }

        public string currency { get; set; }

        public Basis basis { get; set; }
    }
}
