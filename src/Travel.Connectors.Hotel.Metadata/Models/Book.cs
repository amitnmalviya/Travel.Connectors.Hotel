using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class Book
    {
        public Restrictions restrictions { get; set; }
        public string[] requestOptions { get; set; }
        public string[] formOfPaymentsSupported { get; set; }
    }
}
