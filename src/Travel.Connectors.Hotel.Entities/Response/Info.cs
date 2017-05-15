using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Info
    {
        public Info()
        {

        }

        public Info(string errorCode, string errorMessage)
        {
            code = errorCode;
            message = errorMessage;
        }
        public string code { get; set; }
        public string message { get; set; }
    }
}
