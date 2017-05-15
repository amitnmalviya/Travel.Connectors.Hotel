using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.ErrorMapping.Models;
using Travel.Connectors.Hotel.Logger;
using Travel.Connectors.Hotel.Metadata;
using Travel.Connectors.Hotel.Metadata.Models;
using Travel.Connectors.Hotel.Entities;
using Tavisca.Platform.Common.Logging;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        private readonly ILogWriter _logWriter = null;
        private readonly IConnectorMetadata _metadata;
        private readonly IConnectorError _connectorError;
        
        public ValidationMiddleware(RequestDelegate next, ILogWriter logWriter, IConnectorMetadata connectorMetadata, IConnectorError errorMap)
        {
            _nextMiddleware = next;
            _logWriter = logWriter;
            _metadata = connectorMetadata;
            _connectorError = errorMap;
        }

        public async Task Invoke(HttpContext context)
        {
            CommonLogParameters commonParameters = new CommonLogParameters();
            DateTime requestDateTime = DateTime.Now;
            var requestBodyStream = context.Request.Body;
            using (var buffer = new MemoryStream())
            {
                await requestBodyStream.CopyToAsync(buffer);
                buffer.Position = 0L;
                context.Request.Body = buffer;
                using (var bodyReader = new StreamReader(buffer))
                {
                    string requestBody = await bodyReader.ReadToEndAsync();
                    context.Request.Body.Position = 0L;
                    USGSearchRequest usgSearchRequest = null;
                    ErrorInfo errorInfo = null;
                    try
                    {
                        usgSearchRequest = JsonConvert.DeserializeObject<USGSearchRequest>(requestBody);
                        errorInfo = ValidateUsgRequest(usgSearchRequest, context, _connectorError);
                    }
                    catch (JsonReaderException)
                    {
                        errorInfo = FillErrorInfo(_connectorError);
                    }
                    catch (JsonSerializationException)
                    {
                        errorInfo = FillErrorInfo(_connectorError);
                    }

                    if (errorInfo == null)
                    {
                        context.Response.StatusCode = 200;
                        await _nextMiddleware.Invoke(context);
                    }
                    else
                    {
                        USGSearchResponse usgSearchResponse = new USGSearchResponse();
                        usgSearchResponse.errorInfo = errorInfo;
                        context.Response.ContentType = ApplicationConstants.ResponseContentType;
                        context.Response.StatusCode = errorInfo.HttpStatusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(usgSearchResponse.errorInfo));

                        DateTime responseDateTime = DateTime.Now;
                        double middlewareTimetaken = Convert.ToDouble((responseDateTime - requestDateTime).ToString(ApplicationConstants.TimeTakenFormat));
                        LogEntryBuilder.GetRequestFormatValues(context.Request, ref commonParameters);
                        SetCommonParametersValues(usgSearchRequest, commonParameters);
                        TransactionLogEntry usgLogEntry = LogEntryBuilder.GetUsgLogEntry(usgSearchRequest, usgSearchResponse, middlewareTimetaken, commonParameters);
                        await _logWriter.WriteAsync(usgLogEntry);
                    }
                }
            }
        }


        private ErrorInfo ValidateUsgRequest(USGSearchRequest usgSearchRequest, HttpContext context, IConnectorError connectorError)
        {
            if (context.Request.Path.ToString().Equals("/api/GetARoom/Healthcheck", StringComparison.OrdinalIgnoreCase))
                return null;

            ErrorInfo errorInfo = null;

            if (usgSearchRequest == null)
                errorInfo = FillErrorInfo(connectorError);
            else
            {
                if (!context.Request.Headers.Keys.Contains(ApplicationConstants.CorelationIdHeader))
                    errorInfo = FillErrorInfo(connectorError, ApplicationConstants.CorelationIdHeaderRequired);

                if (!context.Request.Headers.Keys.Contains(ApplicationConstants.OskiTenantId))
                    errorInfo = FillErrorInfo(connectorError, ApplicationConstants.TenantIdRequired);
                else if (!context.Request.Headers.Keys.Contains(ApplicationConstants.OskiUserToken))
                {
                    ErrorBuilder errorBuilder = new ErrorBuilder(connectorError);
                    errorBuilder.MapError(ApplicationConstants.UserTokenRequired, ApplicationConstants.InvalidRequest, ApplicationConstants.OskiUserToken);
                    errorInfo = errorBuilder.ErrorInfo;
                }
                else if (context.Request.Headers.Keys.Contains(ApplicationConstants.AcceptLanguage) && (string.Equals(context.Request.Headers.Single(header => header.Key == ApplicationConstants.AcceptLanguage).Value, ApplicationConstants.AcceptLanguageValue, StringComparison.OrdinalIgnoreCase)))
                {
                    MetadataResponse getARoomMetadata = _metadata.ReadMetaData();
                    errorInfo = usgSearchRequest.IsUSGSearchRequestValid(getARoomMetadata, connectorError);
                }
                else
                    errorInfo = FillErrorInfo(connectorError, ApplicationConstants.AcceptLanguageInvalid);
            }
            return errorInfo;
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
                    message = usgError.ErrorMessage,
                    HttpStatusCode = Convert.ToInt32(usgError.HttpStatusCode)
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
                else
                    errorInfo.info = null;
            }
            return errorInfo;
        }

        private void SetCommonParametersValues(USGSearchRequest usgSearchRequest, CommonLogParameters commonParameters)
        {
            if (usgSearchRequest != null && !string.IsNullOrEmpty(usgSearchRequest.Supplier.Id))
                commonParameters.SupplierId = usgSearchRequest.Supplier.Id;

            if (usgSearchRequest != null && !string.IsNullOrEmpty(usgSearchRequest.Supplier.Name))
                commonParameters.SupplierName = usgSearchRequest.Supplier.Name;

            commonParameters.Status = StatusOptions.Failure;
        }
    }
}
