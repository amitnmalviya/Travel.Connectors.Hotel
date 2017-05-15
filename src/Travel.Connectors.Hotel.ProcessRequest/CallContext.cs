using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Context;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public class CallContext : AmbientContextBase
    {
        public new static CallContext Current
        {
            get
            {
                return AmbientContextBase.Current as CallContext;
            }
        }

        private ConcurrentDictionary<string, string> _additionalData;

        public CallContext(string culture, string tenantId, string corelationId, string applicationName, string userIdentifier, string ipAddress = null)
        {
            try
            {
                Culture = new CultureInfo(culture);
            }
            catch
            {
                //Ignore exception
            }

            TenantId = tenantId;
            IpAddress = ipAddress;
            ApplicationName = applicationName;
            CorrelationId = corelationId;
            UserIdentifier = userIdentifier;
            _additionalData = new ConcurrentDictionary<string, string>();
        }

        public static void SetSessionId(string sessionId)
        {
            Current.SessionId = sessionId;
        }

        public CultureInfo Culture { get; private set; }

        public string SessionId { get; private set; }

        public string IpAddress { get; private set; }

        public string TenantId { get; private set; }

        public string CorrelationId { get; private set; }

        public string UserIdentifier { get; private set; }

        public void AddData(string key, string value)
        {
            Current._additionalData.TryAdd(key, value);
        }

        public string GetData(string key)
        {
            var value = string.Empty;
            if (!string.IsNullOrWhiteSpace(key))
                Current._additionalData.TryGetValue(key, out value);
            return value;
        }

        public Dictionary<string, string> GetAllData()
        {
            return Current._additionalData.ToDictionary(kvp => kvp.Key,
                                                          kvp => kvp.Value);
        }

    }
}
