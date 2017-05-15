
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    [Serializable]
    public partial class SystemException : BaseApplicationException
    {
        public SystemException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

		public SystemException(ErrorInfo info) : base(info.Code, info.Message, info.HttpStatusCode,info.Info) { }

		public SystemException( string code, string message, HttpStatusCode httpStatusCode, Exception inner) : base(code, message, httpStatusCode, inner){ }
    }
}
