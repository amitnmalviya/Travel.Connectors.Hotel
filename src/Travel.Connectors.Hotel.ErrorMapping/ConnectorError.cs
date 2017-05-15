using Newtonsoft.Json;
using System;
using System.IO;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.ErrorMapping.Models;
using Travel.Connectors.Hotel.ErrorMapping.Resources;

namespace Travel.Connectors.Hotel.ErrorMapping
{
    public class ConnectorError : IConnectorError
    {
        public UsgError GetUsgError(string errorCode)
        {
            UsgError usgError = null;
            string usgErrorKey = ApplicationConstants.ErrorCodePrefix + errorCode;
            string supplierUsgErrorMapJsonString = GetSupplierUsgErrorMapJson();

            var errorMaps = (SupplierUsgErrorMap)JsonConvert.DeserializeObject(supplierUsgErrorMapJsonString, typeof(SupplierUsgErrorMap));
            if (errorMaps != null && errorMaps.errorMap != null && errorMaps.errorMap.Count > 0)
            {
                ErrorMap supplierUsgErrorMap = errorMaps.errorMap.Find(errorMap => errorMap.UsgErrorCode.Equals(errorCode, StringComparison.OrdinalIgnoreCase));

                if (supplierUsgErrorMap != null)
                {
                    usgError = new UsgError
                    {
                        ErrorCode = supplierUsgErrorMap.UsgErrorCode,
                        ErrorMessage = USGErrors.ResourceManager.GetString(usgErrorKey),
                        ErrorCategory = supplierUsgErrorMap.ErrorCategory,
                        ErrorType = supplierUsgErrorMap.ErrorType,
                        HttpStatusCode = supplierUsgErrorMap.HttpStatusCode,
                        Tag = supplierUsgErrorMap.Tag
                    };
                }
            }
            return usgError;
        }

        public UsgError GetUsgMappedError(string supplieErrorCode)
        {
            UsgError usgError = null;
            string supplierErrorKey = ApplicationConstants.ErrorCodePrefix + supplieErrorCode;
            string supplierUsgErrorMapJsonString = GetSupplierUsgErrorMapJson();

            var errorMaps = (SupplierUsgErrorMap)JsonConvert.DeserializeObject(supplierUsgErrorMapJsonString, typeof(SupplierUsgErrorMap));
            if (errorMaps != null && errorMaps.errorMap != null && errorMaps.errorMap.Count > 0)
            {
                ErrorMap supplierUsgErrorMap = errorMaps.errorMap.Find(errorMap => errorMap.GetARoomErrorCode.Equals(supplieErrorCode, StringComparison.OrdinalIgnoreCase));

                if (supplierUsgErrorMap != null)
                {
                    usgError = new UsgError
                    {
                        ErrorCode = supplierUsgErrorMap.UsgErrorCode,
                        ErrorCategory = supplierUsgErrorMap.ErrorCategory,
                        ErrorType = supplierUsgErrorMap.ErrorType,
                        HttpStatusCode = supplierUsgErrorMap.HttpStatusCode,
                        Tag = supplierUsgErrorMap.Tag
                    };
                    usgError.ErrorMessage = USGErrors.ResourceManager.GetString(ApplicationConstants.ErrorCodePrefix + usgError.ErrorCode);
                }
                else
                {
                    usgError = GetUsgError(ApplicationConstants.UsgErrorCodeForUnmapped);
                }
            }
            return usgError;
        }

        private string GetSupplierUsgErrorMapJson()
        {
            string supplierUsgErrorMapJsonString = string.Empty;

            if (!string.IsNullOrEmpty(ApplicationConstants.ErrorMappingFilePath)
                    && File.Exists(ApplicationConstants.ErrorMappingFilePath))
            {
                supplierUsgErrorMapJsonString = File.ReadAllText(ApplicationConstants.ErrorMappingFilePath);
            }

            return supplierUsgErrorMapJsonString;
        }

    }
}
