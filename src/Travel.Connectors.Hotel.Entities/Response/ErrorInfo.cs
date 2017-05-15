using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class ErrorInfo
    {
        private List<Info> _info = new List<Info>();
        public ErrorInfo()
        {

        }
        public ErrorInfo(string errorCode, string errorMessage)
        {
            code = errorCode;
            message = errorMessage;
        }
        public string code { get; set; }
        public string message { get; set; }
        public List<Info> info { get { return _info; } set { _info = value; } }

        [JsonIgnore]
        public int HttpStatusCode { get; set; }
    }
}
