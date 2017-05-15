using System;
using System.Net;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{

    [Serializable]
    public partial class DependencyException : BaseApplicationException
    {
        public DependencyException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

        public DependencyException(ErrorInfo info) : base(info.Code, info.Message, info.HttpStatusCode, info.Info) { }

        public DependencyException(string code, string message, HttpStatusCode httpStatusCode, Exception inner) : base(code, message, httpStatusCode, inner) { }
    }
}