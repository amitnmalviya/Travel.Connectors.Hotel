using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.Profiling;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Common.Utilities;
using Travel.Connectors.Hotel.Entities;
using Travel.Connectors.Hotel.Logger;
using Travel.Connectors.Hotel.Logger.Enum;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public class ProfilerInjector
    {
        private readonly RequestDelegate _nextMiddleware;
        private readonly ILogWriter _logger;

        public ProfilerInjector(RequestDelegate next, ILogWriter logger)
        {
            _nextMiddleware = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            using (var profileScope = new ProfileContext(context.Request.Path.ToString().Split('/').LastOrDefault().Split('?').FirstOrDefault(), true))
            {
                profileScope.OnDispose +=
                    (profileTreeNode) => { _logger.WriteAsync(profileTreeNode.ToTransactionLogEntry(context)); };
                await _nextMiddleware.Invoke(context);
            }
        }
    }

    public static class Extension
    {
        public static TransactionLogEntry ToTransactionLogEntry(this ProfileTreeNode profileTreeNode, HttpContext context)
        {
            CommonLogParameters commonParameters = new CommonLogParameters();
            LogEntryBuilder.GetRequestFormatValues(context.Request, ref commonParameters);

            return new TransactionLogEntry
            {
                ApplicationName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
                AdditionalData = GetAdditionalData(commonParameters),
                Category = LogCategory.ProfilerTrace.ToString(),
                CorrelationId = commonParameters.CorelationId,
                IpAddress = CommonUtility.GetIPAddress(),
                MachineName = Environment.MachineName,
                ProcessId = Process.GetCurrentProcess().Id.ToString(),
                ProcessName = Process.GetCurrentProcess().ProcessName,
                TenantId = commonParameters.ContextIdentifier,
                Title = ApplicationConstants.ProfilingTitle,
                MethodName = $"{profileTreeNode?.PerformanceLog?.Info}.{ApplicationConstants.Profiling}",
                UserIdentifier = commonParameters.UserIdentifier,
                ServiceUrl = commonParameters.UsgRequestUrl,
                ResponseObject = profileTreeNode,
                TimeTaken = profileTreeNode?.PerformanceLog?.TotalExecutionTime?.TotalSeconds ?? 0
            };
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
