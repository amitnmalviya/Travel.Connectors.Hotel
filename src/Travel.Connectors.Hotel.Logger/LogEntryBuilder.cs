using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Tavisca.Platform.Common.Logging;
using Travel.Connectors.Hotel.Common.Utilities;
using Travel.Connectors.Hotel.Entities;
using Travel.Connectors.Hotel.Logger.Enum;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.Logger
{
    public static class LogEntryBuilder
    {
        public static ErrorLogEntry GetErrorLogEntry(Exception exception, CommonLogParameters commonParameters)
        {
            ErrorLogEntry errorLogEntry = new ErrorLogEntry
            {
                ApplicationName = ApplicationConstants.ApplicationName,
                Category = LogCategory.ExceptionTrace.ToString(),
                CorrelationId = commonParameters.CorelationId,
                //InstanceId = Guid.NewGuid().ToString(),
                IpAddress = CommonUtility.GetIPAddress(),
                MachineName = Environment.MachineName,
                ProcessId = Process.GetCurrentProcess().Id.ToString(),
                ProcessName = Process.GetCurrentProcess().ProcessName,
                TenantId = commonParameters.ContextIdentifier,
                UserIdentifier = commonParameters.UserIdentifier,
                SessionId = commonParameters.SessionId,
                Message = exception.Message,
                Source = exception.Source,
                InnerExceptions = (exception.InnerException != null) ? exception.InnerException.ToString() : null,
                StackTrace = exception.StackTrace,
                Type = exception.GetType().ToString(),
                Timestamp = DateTime.Now
            };
            return errorLogEntry;
        }

        public static TransactionLogEntry GetUsgLogEntry(object searchRequest, object searchResponse, double timeTaken, CommonLogParameters commonParameters)
        {
            TransactionLogEntry usgLogEntry = new TransactionLogEntry
            {
                ApplicationName = ApplicationConstants.ApplicationName,
                AdditionalData = GetAdditionalData(commonParameters),
                Category = LogCategory.USGTrace.ToString(),
                CorrelationId = commonParameters.CorelationId,
                IpAddress = CommonUtility.GetIPAddress(),
                MachineName = Environment.MachineName,
                ProcessId = Process.GetCurrentProcess().Id.ToString(),
                ProcessName = Process.GetCurrentProcess().ProcessName,
                TenantId = commonParameters.ContextIdentifier,
                Title = ApplicationConstants.UsgTitle,
                MethodName = ApplicationConstants.UsgCalltype,
                UserIdentifier = commonParameters.UserIdentifier,
                ServiceUrl = commonParameters.UsgRequestUrl,
                RequestObject = searchRequest,
                ResponseObject = searchResponse,
                SessionId = commonParameters.SessionId,
                Status = commonParameters.Status,
                TimeTaken = timeTaken,
                Timestamp = DateTime.Now
            };

            foreach (KeyValuePair<string, string> pair in commonParameters.UsgRequestHeader)
                usgLogEntry.RequestHeaders.Add(pair);

            return usgLogEntry;
        }

        public static TransactionLogEntry GetSupplierLogEntry(string searchRequest, string searchResponse, double timeTaken, CommonLogParameters commonParameters)
        {
            TransactionLogEntry supplierLogEntry = new TransactionLogEntry
            {
                ApplicationName = ApplicationConstants.ApplicationName,
                AdditionalData = GetAdditionalData(commonParameters),
                Category = LogCategory.SupplierTrace.ToString(),
                CorrelationId = commonParameters.CorelationId,
                IpAddress = CommonUtility.GetIPAddress(),
                MachineName = Environment.MachineName,
                ProcessId = Process.GetCurrentProcess().Id.ToString(),
                ProcessName = Process.GetCurrentProcess().ProcessName,
                TenantId = commonParameters.ContextIdentifier,
                Title = ApplicationConstants.SupplierTitle,
                MethodName = ApplicationConstants.SupplierCalltype,
                ServiceUrl = commonParameters.SupplierRequestUrl,
                UserIdentifier = commonParameters.UserIdentifier,
                RequestString = searchRequest,
                ResponseString = searchResponse,
                SessionId = commonParameters.SessionId,
                Status = commonParameters.Status,
                TimeTaken = timeTaken,
                Timestamp = DateTime.Now
            };

            foreach (KeyValuePair<string, string> pair in commonParameters.SupplierRequestHeader)
                supplierLogEntry.RequestHeaders.Add(pair);

            return supplierLogEntry;
        }

        public static TransactionLogEntry GetUnmappedLogEntry(string searchRequest, string searchResponse, double timeTaken, CommonLogParameters commonParameters, string unmappedErrorCode)
        {
            TransactionLogEntry unmappedLogEntry = new TransactionLogEntry
            {
                ApplicationName = ApplicationConstants.ApplicationName,
                Category = LogCategory.UnMappedErrorTrace.ToString(),
                CorrelationId = commonParameters.CorelationId,
                IpAddress = CommonUtility.GetIPAddress(),
                MachineName = Environment.MachineName,
                ProcessId = Process.GetCurrentProcess().Id.ToString(),
                ProcessName = Process.GetCurrentProcess().ProcessName,
                TenantId = commonParameters.ContextIdentifier,
                Title = ApplicationConstants.UnmappedTitle,
                MethodName = ApplicationConstants.UnmappedCalltype,
                ServiceUrl = commonParameters.SupplierRequestUrl,
                UserIdentifier = commonParameters.UserIdentifier,
                RequestObject = searchRequest,
                ResponseObject = searchResponse,
                SessionId = commonParameters.SessionId,
                Status = commonParameters.Status,
                TimeTaken = timeTaken,
                Timestamp = DateTime.Now
            };

            unmappedLogEntry.AdditionalData = GetAdditionalData(commonParameters);
            unmappedLogEntry.AdditionalData.Add(ApplicationConstants.UnmappedError, unmappedErrorCode);

            foreach (KeyValuePair<string, string> pair in commonParameters.SupplierRequestHeader)
                unmappedLogEntry.RequestHeaders.Add(pair);

            return unmappedLogEntry;
        }

        public static void GetRequestFormatValues(HttpRequest usgRequest, ref CommonLogParameters commonParameters)
        {
            List<KeyValuePair<string, string>> usgRequestHeader = new List<KeyValuePair<string, string>>();

            if (usgRequest.Headers.Keys.Contains(ApplicationConstants.CorelationIdHeader))
            {
                commonParameters.CorelationId = usgRequest.Headers.Single(header => header.Key == ApplicationConstants.CorelationIdHeader).Value;
                usgRequestHeader.Add(new KeyValuePair<string, string>(ApplicationConstants.CorelationIdHeader, commonParameters.CorelationId));
            }

            if (usgRequest.Headers.Keys.Contains(ApplicationConstants.ContentType))
                usgRequestHeader.Add(new KeyValuePair<string, string>(ApplicationConstants.ContentType, usgRequest.Headers.Single(header => header.Key == ApplicationConstants.ContentType).Value));
            if (usgRequest.Headers.Keys.Contains(ApplicationConstants.AcceptLanguage))
                usgRequestHeader.Add(new KeyValuePair<string, string>(ApplicationConstants.AcceptLanguage, usgRequest.Headers.Single(header => header.Key == ApplicationConstants.AcceptLanguage).Value));

            if (usgRequest.Headers.Keys.Contains(ApplicationConstants.OskiTenantId))
            {
                commonParameters.ContextIdentifier = usgRequest.Headers.Single(header => header.Key == ApplicationConstants.OskiTenantId).Value;
                usgRequestHeader.Add(new KeyValuePair<string, string>(ApplicationConstants.OskiTenantId, usgRequest.Headers.Single(header => header.Key == ApplicationConstants.OskiTenantId).Value));
            }
            if (usgRequest.Headers.Keys.Contains(ApplicationConstants.OskiUserToken))
            {
                commonParameters.UserIdentifier = usgRequest.Headers.Single(header => header.Key == ApplicationConstants.OskiUserToken).Value;
                usgRequestHeader.Add(new KeyValuePair<string, string>(ApplicationConstants.OskiUserToken, usgRequest.Headers.Single(header => header.Key == ApplicationConstants.OskiUserToken).Value));
            }
            commonParameters.UsgRequestUrl = UriHelper.GetDisplayUrl(usgRequest);
            commonParameters.UsgRequestHeader = usgRequestHeader;
        }

        private static Dictionary<string, string> GetAdditionalData(CommonLogParameters commonParameters)
        {
            Dictionary<string, string> additionalData = new Dictionary<string, string>();
            additionalData.Add(ApplicationConstants.ProviderId, commonParameters.SupplierId);
            additionalData.Add(ApplicationConstants.ProviderName, commonParameters.SupplierName);
            additionalData.Add(ApplicationConstants.CorelationIdHeader, commonParameters.CorelationId);
            return additionalData;
        }
    }
}
