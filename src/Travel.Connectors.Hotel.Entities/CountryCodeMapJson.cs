using System;
using System.Collections.Generic;
using System.IO;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.Entities
{
    public class CountryCodeMapJson
    {
        public string GetCountryCodeMapJsonString()
        {
            string countryCodeMapJsonString = string.Empty;
            string filePath = ApplicationConstants.CountryCodeMappingFilePath;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                countryCodeMapJsonString = File.ReadAllText(filePath);
            }

            return countryCodeMapJsonString;
        }
    }
}
