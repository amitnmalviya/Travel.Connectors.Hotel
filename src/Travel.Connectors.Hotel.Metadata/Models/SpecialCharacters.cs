using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class SpecialCharacters
    {
        public char[] allowedCharacters { get; set; }
        public char[] disallowedCharacters { get; set; }
    }
}
