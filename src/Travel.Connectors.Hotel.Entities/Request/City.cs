using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class City
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public State State { get; set; }
        public string CodecountryCode { get; set; }
    }
}
