using System.Collections.Generic;

namespace Travel.Connectors.Hotel.Entities
{
    public class SupplierRequestFormat
    {
        public string Url { get; set; }

        public List<KeyValuePair<string, string>> Header { get; set; }

        public string Body { get; set; }
    }
}
