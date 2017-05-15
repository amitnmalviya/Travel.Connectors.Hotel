using Newtonsoft.Json;

namespace Travel.Connectors.Hotel.Entities
{
    public class HotelInfo
    {
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
    }
}
