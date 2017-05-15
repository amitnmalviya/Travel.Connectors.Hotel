using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class Criteria
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public City City { get; set; }
        public string RadialRegion { get; set; }
        public string[] HotelIds { get; set; }
        public RoomOccupancy[] Occupancies { get; set; }

        public void IsUSGSearchRequestValid(ErrorBuilder errorBuilder, MetadataResponse getARoomMetadata)
        {
            if (CheckIn == DateTime.MinValue)
                errorBuilder.MapError(ApplicationConstants.EmptyCheckin, ApplicationConstants.InvalidRequest, ApplicationConstants.CheckInDate);

            if (CheckIn < DateTime.Today)
                errorBuilder.MapError(ApplicationConstants.PastCheckinDate, ApplicationConstants.InvalidRequest);

            if (CheckOut == DateTime.MinValue)
                errorBuilder.MapError(ApplicationConstants.EmptyCheckin, ApplicationConstants.InvalidRequest, ApplicationConstants.CheckOutDate);

            if (CheckIn != DateTime.MinValue && CheckIn != DateTime.MinValue)
            {
                if (CheckIn > CheckOut)
                    errorBuilder.MapError(ApplicationConstants.CheckoutBeforeCheckin, ApplicationConstants.InvalidRequest);
                else if (CheckIn == CheckOut)
                    errorBuilder.MapError(ApplicationConstants.MinOneDayDifference, ApplicationConstants.InvalidRequest);
                else if (getARoomMetadata.verbs != null && getARoomMetadata.verbs.search != null && (CheckOut - CheckIn).TotalDays > getARoomMetadata.verbs.search.maxStay)
                    errorBuilder.MapError(ApplicationConstants.MaxStayExceed, ApplicationConstants.InvalidRequest, getARoomMetadata.verbs.search.maxStay.ToString());
            }

            if (HotelIds == null || HotelIds.Length <= 0)
                errorBuilder.MapError(ApplicationConstants.EmptySearchPattern, ApplicationConstants.ValidationErrors);

            ValidateOccupancies(errorBuilder, getARoomMetadata);
        }

        private void ValidateOccupancies(ErrorBuilder errorBuilder, MetadataResponse getARoomMetadata)
        {
            if (getARoomMetadata.multiroom != null)
            {
                if (Occupancies != null && Occupancies.Length > getARoomMetadata.multiroom.maxRoomsPerBooking)
                    errorBuilder.MapError(ApplicationConstants.MaxOccupancy, ApplicationConstants.ValidationErrors, getARoomMetadata.multiroom.maxRoomsPerBooking.ToString());

                if (Occupancies != null && Occupancies.Length > 0)
                {
                    int totalGuest = 0;
                    foreach (RoomOccupancy occupancy in Occupancies)
                    {
                        if (occupancy.IsUSGSearchRequestValid(errorBuilder, getARoomMetadata))
                        {
                            totalGuest += occupancy.NumOfAdults;
                            if (occupancy.ChildAges != null && occupancy.ChildAges.Length > 0)
                                totalGuest += occupancy.ChildAges.Length;
                        }
                        else
                            break;
                    }

                    if (totalGuest > getARoomMetadata.guestLimitForBooking)
                        errorBuilder.MapError(ApplicationConstants.MaxGuestsPerBooking, ApplicationConstants.ValidationErrors, getARoomMetadata.guestLimitForBooking.ToString());
                }
                 
                else
                    errorBuilder.MapError(ApplicationConstants.EmptyOccupancy, ApplicationConstants.InvalidRequest);
            }
        }
    }
}
