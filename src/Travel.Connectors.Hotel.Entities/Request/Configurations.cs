using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class Configurations
    {
        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; set; }
        [JsonProperty(PropertyName = "auth_token")]
        public string AuthToken { get; set; }
        public bool Istestbooking { get; set; }
        public string SearchUrl { get; set; }

        public void IsUSGSearchRequestValid(ErrorBuilder errorBuilder, MetadataResponse getARoomMetadata)
        {
            if (string.IsNullOrEmpty(ApiKey))
                errorBuilder.MapError(ApplicationConstants.EmptyUserId, ApplicationConstants.InvalidRequest, ApplicationConstants.SupplierConfigurationUserId, ApplicationConstants.SupplierConfigurationPassword);

            if (string.IsNullOrEmpty(AuthToken))
                errorBuilder.MapError(ApplicationConstants.EmptyPassword, ApplicationConstants.InvalidRequest, ApplicationConstants.SupplierConfigurationUserId, ApplicationConstants.SupplierConfigurationPassword);
        }
    }
}
