using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class CancellationPolicy
    {
        public List<Penalty> penalties { get; set; }
        public string text { get; set; }
    }
}
