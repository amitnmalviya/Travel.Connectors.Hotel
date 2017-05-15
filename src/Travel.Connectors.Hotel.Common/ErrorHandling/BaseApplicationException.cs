using System;
using System.Collections.Generic;
using System.Net;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    public class BaseApplicationException : Exception
    {
        #region Properties
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public List<Info> Info { get; } = new List<Info>();

        #endregion

        #region Constructors       


        public BaseApplicationException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode, List<Info> info = null) : base(errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.HttpStatusCode = httpStatusCode;
            if (info != null)
                Info.AddRange(info);
        }

        public BaseApplicationException(string message, string code) : base(message)
        {
            this.ErrorCode = code;
            this.ErrorMessage = message;
        }

        public BaseApplicationException(string message, string code, HttpStatusCode httpStatusCode, Exception inner) : base(message, inner)
        {
            this.ErrorCode = code;
            this.ErrorMessage = message;
            this.HttpStatusCode = httpStatusCode;
        }

        #endregion
    }
}
