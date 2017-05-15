
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    [Serializable]
    public partial class CommunicationException : BaseApplicationException
    {
        public CommunicationException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

		public CommunicationException(ErrorInfo info) : base(info.Code, info.Message, info.HttpStatusCode,info.Info) { }

		public CommunicationException( string code, string message, HttpStatusCode httpStatusCode, Exception inner) : base(code, message, httpStatusCode, inner){ }
    }
}
