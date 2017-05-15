using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Context;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public class ContextInjector
    {
        private readonly RequestDelegate _nextMiddleware;
        public ContextInjector(RequestDelegate next)
        {
            _nextMiddleware = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string culture = GetHeaderValue(context, HeaderKeys.Culture);
            string tenantId = GetHeaderValue(context, HeaderKeys.TenantId);
            string corelationId = GetHeaderValue(context, HeaderKeys.CorrelationId);
            corelationId = string.IsNullOrEmpty(corelationId) ? Guid.NewGuid().ToString() : corelationId;
            string applicationName = "Tavisca.Hotels.Connector"; //todo: move to constant
            string userIdentifier = GetHeaderValue(context, HeaderKeys.UserToken);
            string ipAddress = GetHeaderValue(context, HeaderKeys.UserIPAddress);

            var profilingNeededString = context.Request.Query?.FirstOrDefault(q => q.Key == "Debug").Value.ToString();
            bool profilingNeeded;
            bool.TryParse(profilingNeededString, out profilingNeeded);

            var callcontext = new CallContext(culture, tenantId, corelationId, applicationName, userIdentifier, ipAddress) { IsProfilingEnabled = profilingNeeded };

            using (new AmbientContextScope(callcontext))
            {
                await _nextMiddleware.Invoke(context);
            }

        }

        private string GetHeaderValue(HttpContext context, string headerKey)
        {
            Microsoft.Extensions.Primitives.StringValues headerValue;
            context.Request.Headers.TryGetValue(headerKey, out headerValue);
            return headerValue.FirstOrDefault();
        }
    }
}
