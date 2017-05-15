using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class Supplier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Configurations Configurations { get; set; }
        public Options Options { get; set; }       

        public void IsUSGSearchRequestValid(ErrorBuilder errorBuilder, MetadataResponse getARoomMetadata)
        {
            if (string.IsNullOrEmpty(Id))
                errorBuilder.MapError(ApplicationConstants.EmptySupplierId, ApplicationConstants.InvalidRequest);

            if (string.IsNullOrEmpty(Name))
                errorBuilder.MapError(ApplicationConstants.EmptySupplierName, ApplicationConstants.InvalidRequest);

            if (Configurations != null)
                Configurations.IsUSGSearchRequestValid(errorBuilder, getARoomMetadata);
            else
                errorBuilder.MapError(ApplicationConstants.EmptyConfiguration, ApplicationConstants.InvalidRequest);

            if (Options != null)
                Options.IsUSGSearchRequestValid(errorBuilder, getARoomMetadata);

        }
    }
}
