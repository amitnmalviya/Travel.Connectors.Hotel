using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Travel.Connectors.Hotel.Logger;
using Travel.Connectors.Hotel.GetARoom.Models;
using Travel.Connectors.Hotel.Entities;
using Travel.Connectors.Hotel.Configuration.Models;
using Travel.Connectors.Hotel.Metadata.Models;
using Travel.Connectors.Hotel.ErrorMapping.Models;
using Travel.Connectors.Hotel.ErrorMapping;
using Tavisca.Platform.Common.Logging;
using System.Collections.Generic;
using Tavisca.Platform.Common.Configurations;
using Tavisca.Platform.Common.Profiling;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Metadata;

namespace Travel.Connectors.Hotel.GetARoom
{
    public class GetARoomProvider : IHotelProvider
    {
        // ToDo: class name naming convetion
        private readonly GetARoomSettings _configSettings;
        private readonly ILogWriter _logWriter = null;
        private double _timeTaken;
        private CommonLogParameters _commonParameters = null;
        private readonly IConnectorError _connectorError;
        private readonly IConnectorMetadata _metadata;

        public GetARoomProvider(IConfigurationProvider configurationProvider, ILogWriter logWriter, IConnectorError connectorError, IConnectorMetadata connectorMetadata)
        {
            _configSettings = configurationProvider.GetGlobalConfiguration<GetARoomSettings>(ApplicationConstants.ConfigurationSettingName, "getaroomsettings");
            _logWriter = logWriter;
            _connectorError = connectorError;
            _commonParameters = new CommonLogParameters();
            _metadata = connectorMetadata;
        }

        public USGSearchResponse SearchHotels(USGSearchRequest usgSearchRequest, CommonLogParameters commonLogParameters)
        {
            USGSearchResponse usgSearchResponse = null;
            using (var profileScope = new ProfileContext("GetARoomProvider.SearchHotels", false))
            {
                MetadataResponse getARoomMetadata = _metadata.ReadMetaData();
                AvailabilityHelper availabilityHelper = new AvailabilityHelper(usgSearchRequest, _logWriter, getARoomMetadata, commonLogParameters, _connectorError);
                _commonParameters = commonLogParameters;
                try
                {
                    string getARoomSearchRequest = availabilityHelper.GetSearchRequest();
                    StringBuilder propertyIds = new StringBuilder();
                    int maxHotelsSupported = usgSearchRequest.Criteria.HotelIds.Length;

                    if (getARoomMetadata != null && getARoomMetadata.verbs != null &&
                        getARoomMetadata.verbs.search != null &&
                        maxHotelsSupported > getARoomMetadata.verbs.search.maxHotelsSupported)
                    {
                        maxHotelsSupported = getARoomMetadata.verbs.search.maxHotelsSupported;
                    }

                    int iHotelIdCount = 0;
                    foreach (string hotelId in usgSearchRequest.Criteria.HotelIds)
                    {
                        if (iHotelIdCount >= maxHotelsSupported)
                            break;
                        propertyIds.Append(ApplicationConstants.propertyId);
                        propertyIds.Append(usgSearchRequest.Criteria.HotelIds[iHotelIdCount]);
                        propertyIds.Append(ApplicationConstants.andSymbol);
                        iHotelIdCount++;
                    }
                    propertyIds.Remove(propertyIds.Length - 1, 1);

                    BuildSupplierRequestHeader(getARoomSearchRequest, propertyIds.ToString());

                    string supplierUrl = usgSearchRequest.Supplier.Configurations.SearchUrl;
                    if (string.IsNullOrWhiteSpace(supplierUrl))
                    {
                        if (usgSearchRequest.Supplier.Configurations.Istestbooking)
                            supplierUrl = _configSettings.TestUrl;
                        else
                            supplierUrl = _configSettings.ProductionUrl;
                    }

                    string searchResponse =
                         ExcecuteMethod(getARoomSearchRequest, propertyIds.ToString(), supplierUrl).GetAwaiter().GetResult();
                    GetARoomSearchResponse getARoomSearchResponse = GetSearchResposneObject(searchResponse);

                    CheckUnmapped(getARoomSearchRequest, getARoomSearchResponse, searchResponse);

                    usgSearchResponse = availabilityHelper.MergeSearchReposne(getARoomSearchResponse);

                    //Log the Supplier Response
                    _commonParameters.SessionId = usgSearchResponse.sessionId;
                    TransactionLogEntry supplierLogEntry = LogEntryBuilder.GetSupplierLogEntry(getARoomSearchRequest, searchResponse, _timeTaken, _commonParameters);
                    _logWriter.WriteAsync(supplierLogEntry);
                }
                catch (Exception exception)
                {
                    ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                    _logWriter.WriteAsync(errorLogEntry);
                }
            }
            return usgSearchResponse;
        }

        private async Task<string> ExcecuteMethod(string searchParameters, string propertyIds, string supplierUrl)
        {
            string searchResponse = string.Empty;
            using (var profileScope = new ProfileContext("GetARoomProvider.ExcecuteMethod", false))
            {
                DateTime requestDateTime = DateTime.Now;
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ApplicationConstants.AcceptEncoding,
                            ApplicationConstants.gzip);
                        using (
                            var content = new StringContent(propertyIds, Encoding.GetEncoding(0),
                                ApplicationConstants.applicationXwwwFormUrlencoded))
                        {
                            using (var response = await httpClient.PostAsync(supplierUrl + searchParameters, content))
                            {
                                    searchResponse = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                    _logWriter.WriteAsync(errorLogEntry);
                }
                finally
                {
                    //Stop the timer as you get the Supplier Search Response
                    DateTime responseDateTime = DateTime.Now;
                    _timeTaken = Convert.ToDouble((responseDateTime - requestDateTime).ToString(ApplicationConstants.TimeTakenFormat));
                }
            }
            return searchResponse;
        }

        private GetARoomSearchResponse GetSearchResposneObject(string searchRespones)
        {
            GetARoomSearchResponse getARoomReposnse = new GetARoomSearchResponse();
            using (var profileScope = new ProfileContext("GetARoomProvider.GetSearchResposneObject", false))
            {
                try
                {
                    searchRespones = searchRespones.Replace(ApplicationConstants.xmlHeader, ApplicationConstants.emptyString);
                    searchRespones = searchRespones.Replace(ApplicationConstants.xsiNil, ApplicationConstants.emptyString);

                    using (var strReader = new StringReader(searchRespones))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(GetARoomSearchResponse));
                        getARoomReposnse = (GetARoomSearchResponse)serializer.Deserialize(strReader);
                    }
                }
                catch (Exception exception)
                {
                    ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                    _logWriter.WriteAsync(errorLogEntry);
                }
            }
            return getARoomReposnse;
        }

        private void BuildSupplierRequestHeader(string searchParameters, string body)
        {
            StringBuilder supplierUrl = new StringBuilder();
            try
            {
                supplierUrl.Append(_configSettings.TestUrl);
                supplierUrl.Append(searchParameters);
                _commonParameters.SupplierRequestUrl = supplierUrl.ToString();
                List<KeyValuePair<string, string>> supplierHeader = new List<KeyValuePair<string, string>>();
                supplierHeader.Add(new KeyValuePair<string, string>(ApplicationConstants.AcceptEncoding, ApplicationConstants.gzip));
                _commonParameters.SupplierRequestHeader = supplierHeader;
                _commonParameters.SupplierRequestBody = body;
            }
            catch (Exception exception)
            {
                ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                _logWriter.WriteAsync(errorLogEntry);
            }
        }

        private void CheckUnmapped(string getARoomRequest, GetARoomSearchResponse getARoomSearchResponse, string searchResponse)
        {
            try
            {
                if (getARoomSearchResponse?.status != null)
                {
                    if (getARoomSearchResponse.status.errors == null)
                        _commonParameters.Status = StatusOptions.Success;
                    else
                    {
                        _commonParameters.Status = StatusOptions.Failure;
                        UsgError usgError =
                            _connectorError.GetUsgMappedError(getARoomSearchResponse.status.errors.error.code);

                        if (usgError != null &&
                            usgError.ErrorCode == ApplicationConstants.UsgErrorCodeForUnmapped)
                        {
                            TransactionLogEntry unmappedLogEntry = LogEntryBuilder.GetUnmappedLogEntry(getARoomRequest, searchResponse, _timeTaken, _commonParameters, getARoomSearchResponse.status.errors.error.code);
                            _logWriter.WriteAsync(unmappedLogEntry);
                        }
                    }
                }
                else
                    _commonParameters.Status = StatusOptions.Failure;
            }
            catch (Exception exception)
            {
                ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                _logWriter.WriteAsync(errorLogEntry);
            }
        }
    }
}

