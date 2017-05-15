using System;
using System.Collections.Generic;

namespace Travel.Connectors.Hotel.Entities
{
    public class Itinerary
    {
        public HotelInfo hotelInfo { get; set; }
        public Rate rate { get; set; }
        public List<RoomOption> roomOptions { get; set; }
        public Occupancy[] occupancies { get; set; }
        public RoomRate roomRate { get; set; }
    }
}
