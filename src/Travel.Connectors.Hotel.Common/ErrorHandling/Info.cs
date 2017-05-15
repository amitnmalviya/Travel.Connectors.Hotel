using System;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    public sealed class Info
    {
        public string Code { get; }
        public string Message { get; set; }

        public Info(string errorCode)
        {
            if (string.IsNullOrWhiteSpace(errorCode))
                throw new ArgumentNullException(nameof(errorCode));

            Code = errorCode;
        }

        public Info(string errorCode, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorCode))
                throw new ArgumentNullException(nameof(errorCode));

            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            Code = errorCode;
            Message = errorMessage;
        }
    }
}
