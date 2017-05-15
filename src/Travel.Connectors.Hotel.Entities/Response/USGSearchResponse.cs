using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class USGSearchResponse : Response
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sessionId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Itinerary> itineraries { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorInfo errorInfo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Warning> warnings { get; set; }
        [JsonIgnore]
        public int HttpStatusCode { get; set; }
    }
}
