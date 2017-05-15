using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    public sealed class ErrorInfo
    {
        public string Code { get; }

        public string Message { get; }

        public HttpStatusCode HttpStatusCode { get; }

        public List<Info> Info { get; private set; }

        public ErrorInfo(string errorCode, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorCode))
                throw new ArgumentNullException(nameof(errorCode));

            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            Code = errorCode;
            Message = errorMessage;
            HttpStatusCode = HttpStatusCode.InternalServerError;
            Info = new List<Info>();
        }

        public ErrorInfo(string errorCode, string errorMessage, HttpStatusCode httpStatusCode) : this(errorCode, errorMessage)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ErrorInfo(string errorCode, string errorMessage, HttpStatusCode httpStatusCode, IEnumerable<Info> info) : this(errorCode, errorMessage, httpStatusCode)
        {
            if (info != null)
                Info.AddRange(info);
        }

        public static ErrorInfo FromBaseApplicationException(BaseApplicationException ex)
        {
            var errorInfo = new ErrorInfo(ex.ErrorCode, ex.ErrorMessage, ex.HttpStatusCode);
            errorInfo.Info.AddRange(ex.Info);
            return errorInfo;
        }

        public static ErrorInfo InternalServerError()
        {
            var errorInfo = new ErrorInfo("34", "An application exception occurred", HttpStatusCode.InternalServerError);
            return errorInfo;
        }
    }
}
