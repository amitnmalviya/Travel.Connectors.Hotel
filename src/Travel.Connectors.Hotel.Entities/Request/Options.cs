using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class Options
    {
        public string[] RateCodes { get; set; }
        public string TravellerNationality { get; set; }
        public string TravellerCountryOfResidence { get; set; }
        public string Currency { get; set; }
        public void IsUSGSearchRequestValid(ErrorBuilder errorBuilder, MetadataResponse getARoomMetadata)
        {
            if (!string.IsNullOrEmpty(Currency) && getARoomMetadata.supportedCurrencies != null && getARoomMetadata.supportedCurrencies.Length > 0)
            {
                if (!getARoomMetadata.supportedCurrencies.Any(
                            supportedCurrency => supportedCurrency.Equals(Currency, StringComparison.OrdinalIgnoreCase)))
                    errorBuilder.MapError(ApplicationConstants.UnSupportedCurrency, ApplicationConstants.InvalidRequest);
            }
            if (!string.IsNullOrEmpty(TravellerNationality))
            {
                if (!ValidateCountryCode(TravellerNationality))
                    errorBuilder.MapError(ApplicationConstants.InvalidCountryCode, ApplicationConstants.InvalidRequest);
            }

            if (!string.IsNullOrEmpty(TravellerCountryOfResidence))
            {
                if (!ValidateCountryCode(TravellerCountryOfResidence))
                    errorBuilder.MapError(ApplicationConstants.InvalidCountryCode, ApplicationConstants.InvalidRequest);
            }
        }

        private bool ValidateCountryCode(string countryCode)
        {
            try
            {
                CountryCodeMapJson countryCodeMapJson = new CountryCodeMapJson();
                string countryCodeMapJsonString = countryCodeMapJson.GetCountryCodeMapJsonString();
                bool hasCountryCode = false;
                var countryCodes = (CountryCodeMap)JsonConvert.DeserializeObject(countryCodeMapJsonString, typeof(CountryCodeMap));

                if (countryCodes != null && countryCodes.countryCode != null && countryCodes.countryCode.Count > 0)
                    hasCountryCode = countryCodes.countryCode.Any(country => country.Code == countryCode);

                return hasCountryCode;
            }
            catch (ArgumentException)
            {
                // The code was not a valid country code
                return false;
            }
        }
    }
}