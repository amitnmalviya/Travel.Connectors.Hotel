using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class PerBookingRates
    {
        public List<RateOccupancy> rateOccupancies { get; set; }
        public string code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string desc { get; set; }
        public string type { get; set; }
        public string inventoryType { get; set; }
        public string currency { get; set; }
        public double total { get; set; }
        public Breakup breakup { get; set; }
        public DailyRoomRates dailyRoomRates { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Roombreakup[] perRoomBreakups { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BookingRequirement bookingRequirement { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? refundable { get; set; }
        public bool onRequest { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CancellationPolicy cancellationPolicy { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BoardBasis boardBasis { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] additionalCharges { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> inclusions { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Policies policies { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Offer offer { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double rackRate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Commission commission { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double packageSaving { get; set; }
    }
}
