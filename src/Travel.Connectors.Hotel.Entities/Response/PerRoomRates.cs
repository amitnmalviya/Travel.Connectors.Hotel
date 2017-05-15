using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class PerRoomRates
    {
        public RateOccupancy rateOccupancy { get; set; }
        public string code { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public string inventoryType { get; set; }
        public string currency { get; set; }
        public double total { get; set; }
        public Breakup breakup { get; set; }
        public DailyRoomRates dailyRoomRates { get; set; }
        public BookingRequirement bookingRequirement { get; set; }
        public bool refundable { get; set; }
        public bool onRequest { get; set; }
        public CancellationPolicy cancellationPolicy { get; set; }
        public BoardBasis boardBasis { get; set; }
        public string additionalCharges { get; set; }
        public string inclusions { get; set; }
        public Policies policies { get; set; }
        public Offer offer { get; set; }
        public double rackRate { get; set; }
        public Commission commission { get; set; }
        public double packageSaving { get; set; }
    }
}
