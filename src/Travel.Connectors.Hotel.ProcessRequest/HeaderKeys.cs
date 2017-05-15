using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public class HeaderKeys
    {
        public const string Culture = "accept-language";
        public const string TenantId = "oski-tenantId";
        public const string CorrelationId = "oski-correlationId";
        public const string UserIPAddress = "oski-userIPAddress";
        public const string ContentType = "Content-Type";
        public const string UserToken = "oski-userToken";
        public const string IPAddress = "oski-user-ip";
    }
}
