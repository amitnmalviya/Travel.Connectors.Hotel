using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.ErrorMapping.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class ErrorBuilder
    {
        private readonly IConnectorError connectorError;

        public ErrorBuilder(IConnectorError connectorProvider)
        {
            connectorError = connectorProvider;
        }

        public ErrorInfo ErrorInfo { get; set; }

        public void MapError(string errorInfoCode, string errorCode, params object[] replaceWords)
        {
            if (ErrorInfo == null)
            {
                ErrorInfo = new ErrorInfo();
                UsgError usgMainError = connectorError.GetUsgError(errorCode);
                if (usgMainError != null)
                {
                    ErrorInfo.code = usgMainError.ErrorCode;
                    ErrorInfo.message = usgMainError.ErrorMessage;
                    ErrorInfo.HttpStatusCode = Convert.ToInt32(usgMainError.HttpStatusCode);
                }
            }

            UsgError usgError = connectorError.GetUsgError(errorInfoCode);
            Info info = new Info();
            if (usgError != null)
            {
                if (replaceWords.Length != 0)
                    usgError.ErrorMessage = string.Format(usgError.ErrorMessage, replaceWords);

                info.code = usgError.ErrorCode;
                info.message = usgError.ErrorMessage;
            }

            if (ErrorInfo.info == null)
                ErrorInfo.info = new List<Info>();

            ErrorInfo.info.Add(info);
        }
    }
}
