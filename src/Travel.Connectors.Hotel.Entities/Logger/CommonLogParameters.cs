using System.Collections.Generic;
using Tavisca.Platform.Common.Logging;

namespace Travel.Connectors.Hotel.Entities
{
    public class CommonLogParameters
    {
        public string CorelationId { get; set; }
        public string ContextIdentifier { get; set; }
        public string UserIdentifier { get; set; }
        public string SessionId { get; set; }
        public string UsgRequestUrl { get; set; }
        public List<KeyValuePair<string,string>> UsgRequestHeader { get; set; }
        public string SupplierRequestUrl { get; set; }
        public List<KeyValuePair<string, string>> SupplierRequestHeader { get; set; }
        public string SupplierRequestBody { get; set; }
        public StatusOptions Status { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}

