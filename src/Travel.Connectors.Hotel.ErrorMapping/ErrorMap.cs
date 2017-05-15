using System;
using System.Collections.Generic;

namespace Travel.Connectors.Hotel.ErrorMapping
{
    public class ErrorMap
    {
        public string UsgErrorCode { get; set; }
        public string GetARoomErrorCode { get; set; }
        public string HttpStatusCode { get; set; }
        public string ErrorCategory { get; set; }
        public string ErrorType { get; set; }
        public string Tag { get; set; }
    }
}
