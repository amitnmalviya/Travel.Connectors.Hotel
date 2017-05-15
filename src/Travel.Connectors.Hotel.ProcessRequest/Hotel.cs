using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.ErrorMapping.Models;
using Travel.Connectors.Hotel.Logger;
using Travel.Connectors.Hotel.Entities;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.Profiling;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public class Hotel : IHotel
    {
        protected CommonLogParameters _commonParameters = null;
        private readonly ILogWriter _logWriter = null;
        private readonly IHotelProvider _getARoomProvider = null;

        public Hotel(IHotelProvider getARoomProvider, ILogWriter logWriter)
        { 
            _getARoomProvider = getARoomProvider;
            _logWriter = logWriter;
            _commonParameters = new CommonLogParameters();
        }

        public USGSearchResponse SearchHotels(USGSearchRequest usgSearchRequest, HttpRequest request)
        {
            USGSearchResponse usgSearchResponse = new USGSearchResponse();
            using (var profileScope = new ProfileContext("Hotel.SearchHotels", false))
            {
                try
                {
                    double timeTaken;
                    LogEntryBuilder.GetRequestFormatValues(request, ref _commonParameters);
                    //Start Timer
                    DateTime requestDateTime = DateTime.Now;

                    if (!string.IsNullOrEmpty(usgSearchRequest.Supplier.Id))
                        _commonParameters.SupplierId = usgSearchRequest.Supplier.Id;

                    if (!string.IsNullOrEmpty(usgSearchRequest.Supplier.Name))
                        _commonParameters.SupplierName = usgSearchRequest.Supplier.Name;

                    usgSearchResponse = _getARoomProvider.SearchHotels(usgSearchRequest, _commonParameters);

                    if (usgSearchResponse != null)
                    {
                        _commonParameters.SessionId = usgSearchResponse.sessionId;
                        _commonParameters.Status = (usgSearchResponse.errorInfo == null)
                            ? StatusOptions.Success
                            : StatusOptions.Failure;
                    }

                    //Stop the timer as you get the Usg Search Response
                    DateTime responseDateTime = DateTime.Now;
                    timeTaken = Convert.ToDouble((responseDateTime - requestDateTime).ToString(ApplicationConstants.TimeTakenFormat));

                    TransactionLogEntry usgLogEntry = LogEntryBuilder.GetUsgLogEntry(usgSearchRequest, usgSearchResponse, timeTaken, _commonParameters);
                    _logWriter.WriteAsync(usgLogEntry);
                }
                catch (Exception exception)
                {
                    ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                    _logWriter.WriteAsync(errorLogEntry);
                }

                return usgSearchResponse;
            }
        }

        private ErrorInfo FillErrorInfo(IConnectorError connectorError)
        {
            return FillErrorInfo(connectorError, string.Empty);
        }

        private ErrorInfo FillErrorInfo(IConnectorError connectorError, string errorCode)
        {
            ErrorInfo errorInfo = null;
            UsgError usgError = connectorError.GetUsgError(ApplicationConstants.InvalidRequest);

            if (usgError != null)
            {
                errorInfo = new ErrorInfo
                {
                    code = usgError.ErrorCode,
                    message = usgError.ErrorMessage
                };

                if (!string.IsNullOrEmpty(errorCode))
                {
                    UsgError usgInfoError = connectorError.GetUsgError(errorCode);
                    if (usgInfoError != null)
                    {
                        List<Info> infoList = new List<Info>();
                        Info info = new Info
                        {
                            code = usgInfoError.ErrorCode,
                            message = usgInfoError.ErrorMessage
                        };
                        infoList.Add(info);
                        errorInfo.info = infoList;
                    }
                }
            }
            return errorInfo;
        }
    }   
}
