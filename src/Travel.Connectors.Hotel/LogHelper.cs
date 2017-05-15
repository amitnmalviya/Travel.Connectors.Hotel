using System;
using System.Collections.Generic;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.Profiling;

namespace Travel.Connectors.Hotel
{
    public static class LogHelper
    {
        public static ErrorLogEntry ToEntry(this Exception exception)
        {
            var errorLogEntry = new ErrorLogEntry
            {
                Source = exception.Source,
                Message = exception.Message,
                InnerExceptions = exception.InnerException?.ToString(),
                StackTrace = exception.StackTrace,
                Category = Constants.Logging.Exceptions.Category,
                Title = Constants.Logging.Exceptions.Title,
                Type = exception.GetType().Name,
            };

            foreach (var key in exception.Data.Keys)
                errorLogEntry.AdditionalInfo.Add(key.ToString(), exception.Data[key.ToString()].ToString());

            return errorLogEntry;
        }

        public static TransactionLogEntry GetTransactionEntry(object request, object response, string methodName, string serviceUrl, StatusOptions status, double timeTaken = 0, string title = null, Dictionary<string, string> additionalInfo = null)
        {
            return new TransactionLogEntry
            {
                Category = Constants.Logging.Category,
                MethodName = methodName,
                ServiceUrl = serviceUrl,
                RequestObject = request,
                ResponseObject = response,
                Status = status,
                TimeTaken = timeTaken,
                Title = string.IsNullOrEmpty(title) ? Constants.Logging.Title : title,
                AdditionalData = additionalInfo
            };
        }

        public static TransactionLogEntry ToTransactionLogEntry(this ProfileTreeNode profileTreeNode)
        {
            return new TransactionLogEntry
            {
                MethodName = $"{profileTreeNode?.PerformanceLog?.Info}.{Constants.Profiling}",
                ResponseObject = profileTreeNode,
                TimeTaken = profileTreeNode?.PerformanceLog?.TotalExecutionTime?.TotalSeconds ?? 0
            };
        }
    }

    public static class Constants
    {
        public static class Logging
        {
            public static class Exceptions
            {
                public static readonly string Category = "RedisLogger";
                public static readonly string Title = "Error";
            }

            public static readonly string Category = "RedisLogger";

            public static readonly string Title = "Transaction";
        }

        public static readonly string SupplierAccountId = "SupplierAccountId";

        public static readonly string SupplierAccountName = "SupplierAccountName";

        public static readonly string ConnectorId = "ConnectorId";

        public static readonly string Profiling = "Profiling";
    }
}
