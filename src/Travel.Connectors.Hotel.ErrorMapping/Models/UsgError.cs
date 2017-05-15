using System;
using System.Collections.Generic;

namespace Travel.Connectors.Hotel.ErrorMapping.Models
{
    public class UsgError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string HttpStatusCode { get; set; }
        public string ErrorCategory { get; set; }
        public string ErrorType { get; set; }
        public string Tag { get; set; }
    }
}
