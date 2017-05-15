using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class Status
    {
        public string success { get; set; }
        public Errors errors { get; set; }
    }
}
