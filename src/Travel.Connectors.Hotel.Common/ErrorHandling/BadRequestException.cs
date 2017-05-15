
using System;
using System.Net;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    [Serializable]
    public partial class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

        public BadRequestException(ErrorInfo info) : base(info.Code, info.Message, info.HttpStatusCode, info.Info) { }

        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode, Exception inner) : base(code, message, httpStatusCode, inner) { }
    }
}
