using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class RoomOccupancy
    {
        public int NumOfAdults { get; set; }
        public int[] ChildAges { get; set; }
        public bool IsUSGSearchRequestValid(ErrorBuilder errorBuilder, MetadataResponse getARoomMetadata)
        {
            bool isValid = true;
            if (NumOfAdults <= 0)
            {
                errorBuilder.MapError(ApplicationConstants.MinOneAdult, ApplicationConstants.InvalidRequest);
                isValid = false;
            }
            else
            {
                int guestsInaRoom = NumOfAdults;
                if (ChildAges != null && ChildAges.Length > 0)
                {
                    guestsInaRoom += ChildAges.Length;

                    foreach (int childAge in ChildAges)
                    {
                        if (getARoomMetadata.verbs != null && getARoomMetadata.verbs.search != null &&
                               childAge > getARoomMetadata.verbs.search.maxAllowedChildAge)
                        {
                            errorBuilder.MapError(ApplicationConstants.MaxChildAge, ApplicationConstants.InvalidRequest, ApplicationConstants.MinAllowedChildAge, getARoomMetadata.verbs.search.maxAllowedChildAge.ToString());
                            isValid = false;
                        }
                    }
                }

                if (guestsInaRoom > getARoomMetadata.multiroom.maxGuestsPerRoom)
                {
                    errorBuilder.MapError(ApplicationConstants.MaxGuestsPerRoom, ApplicationConstants.ValidationErrors, getARoomMetadata.multiroom.maxGuestsPerRoom.ToString());
                    isValid = false;
                }
            }
            return isValid;
        }
    }

}
