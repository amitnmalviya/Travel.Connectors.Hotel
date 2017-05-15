using System.Collections.Generic;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class USGSearchRequest : Request
    {
        public Criteria Criteria { get; set; }
        public Supplier Supplier { get; set; }

        public List<string> OptionalFields { get; set; }

        public override ErrorInfo IsUSGSearchRequestValid(MetadataResponse getARoomMetadata, IConnectorError errrorProvider)
        {
            ErrorBuilder errorBuilder = new ErrorBuilder(errrorProvider);

            if (Criteria != null)
                Criteria.IsUSGSearchRequestValid(errorBuilder, getARoomMetadata);
            else
               errorBuilder.MapError(ApplicationConstants.EmptyCriteria, ApplicationConstants.InvalidRequest);

            if (Supplier != null)
                Supplier.IsUSGSearchRequestValid(errorBuilder, getARoomMetadata);
            else
                errorBuilder.MapError(ApplicationConstants.EmptySupplier, ApplicationConstants.InvalidRequest);

            return errorBuilder.ErrorInfo;
        }
    }
}
