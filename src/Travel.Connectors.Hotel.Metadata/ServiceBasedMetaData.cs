using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Configuration.Models;
using Travel.Connectors.Hotel.Metadata.Models;
using Microsoft.Extensions.Caching.Memory;
using Tavisca.Platform.Common.Configurations;
using Travel.Connectors.Hotel.Common;
using Tavisca.Platform.Common.Profiling;

namespace Travel.Connectors.Hotel.Metadata
{
    public class ServiceBasedMetadata : IConnectorMetadata
    {
        private readonly ApplicationSettings applicationsettings = null;
        private readonly IMemoryCache memoryCache = null;

        public ServiceBasedMetadata(IConfigurationProvider configurationProvider, IMemoryCache cache)
        {
            applicationsettings = configurationProvider.GetGlobalConfiguration<ApplicationSettings>(ApplicationConstants.ConfigurationSettingName, "applicationsettings");
            memoryCache = cache;
        }

        public MetadataResponse ReadMetaData()
        {
            MetadataResponse metaDataResponse = null;
            using (var profileScope = new ProfileContext("ServiceBasedMetadata.ReadMetaData", false))
            {
                if (memoryCache == null)
                {
                    metaDataResponse = GetMetadata();
                }
                else if (!memoryCache.TryGetValue(ApplicationConstants.ServiceMetadata, out metaDataResponse))
                {
                    metaDataResponse = GetMetadata();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(ApplicationConstants.CacheTimeoutInSeconds));

                    memoryCache.Set(ApplicationConstants.ServiceMetadata, metaDataResponse, cacheEntryOptions);
                }
            }
            return metaDataResponse;
        }

        private MetadataResponse GetMetadata()
        {
            MetadataResponse metaDataResponse = new MetadataResponse();
            string metadata = ReadMetadata().GetAwaiter().GetResult();
            metaDataResponse = JsonConvert.DeserializeObject<MetadataResponse>(metadata);
            return metaDataResponse;
        }

        private async Task<string> ReadMetadata()
        {
            string searchResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(applicationsettings.metadataserviceurl))
                {
                    searchResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return searchResponse;
        }
    }
}
