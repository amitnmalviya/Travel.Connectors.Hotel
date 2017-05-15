using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class Restrictions
    {
        public int firstNameMaxLength { get; set; }
        public int lastNameMaxLength { get; set; }
        public SpecialCharacters specialCharacters { get; set; }
    }
}
