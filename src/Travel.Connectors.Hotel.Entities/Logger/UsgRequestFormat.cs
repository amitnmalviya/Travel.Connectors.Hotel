using System.Collections.Generic;

namespace Travel.Connectors.Hotel.Entities
{
    public class UsgRequestFormat
    {
        public string Url { get; set; }

        public List<KeyValuePair<string, string>> Header { get; set; }

        public USGSearchRequest Body { get; set; }
    }
}
