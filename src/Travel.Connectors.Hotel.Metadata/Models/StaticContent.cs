using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class StaticContent
    {
        public string[] cultures { get; set; }
        public string[] source { get; set; }
        public string updateFrequency { get; set; }
    }
}
