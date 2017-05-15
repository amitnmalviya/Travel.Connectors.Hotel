
namespace Travel.Connectors.Hotel.Common
{
    public static class ApplicationConstants
    {
        public static string ApplicationName = "Tavisca.Connector.Hotels";

        // File log settings
        public const string ExceptionLogsPath = ".//TaviscaLogs//ExceptionLogs//ExceptionLog.json";
        public const long MaxSizeExceptionLogFile = 4000;
        public const string USGLogFilePath = ".//TaviscaLogs//USGLogs//";
        public const string SupplierLogFilePath = ".//TaviscaLogs//SupplierLogs//";
        public const string UnmappedErrorLogPath = ".//TaviscaLogs//UnmappedErrorLogs//";
        public const string DefaultLogPath = ".//TaviscaLogs//OtherLogs//";
        public const string ProfilerLogPath = ".//TaviscaLogs//ProfilerLogs//";

        // Logging application constants
        public const string TimeStampFormat = "yyyy'-'MM'-'dd HH':'mm':'ss'Z'";
        public const string FileTimeStampFormat = "yyMMdd-HHmmssfffffff";
        public const string LogFileExtension = ".json";
        public const string BackupExceptionFileString = "_BAK";
        public const string USGLogType = "USG";
        public const string SupplierLogType = "Supplier";
        public const string TimeTakenFormat = "ss\\.ffffff";
        public const string SuccessIdentifier = "Success";
        public const string FailureIdentifier = "Failure";
        public const string GetIpHost = "8.8.8.8";
        public const int GetIpPort = 65530;
        public const string ProviderId = "ProviderId";
        public const string ProviderName = "ProviderName";
        public const string UnmappedError = "unMappedError";

        // Usg Request Header Constants
        public const string ContentType = "Content-Type";
        public const string AcceptLanguage = "Accept-Language";
        public const string AcceptLanguageValue = "en-US";
        public const string AcceptEncoding = "Accept-Encoding";
        public const string CorelationIdHeader = "oski-correlationId";
        public const string OskiTenantId = "oski-tenantId";
        public const string OskiUserToken = "oski-userToken";

        // Log Format static fields information
        public const string UsgCalltype = "Connector.search.rootlog";
        public const string SupplierCalltype = "GetARoom.Search.multiPropertyAvail";
        public const string UnmappedCalltype = "getaroom.search.unmapped";
        public const string UsgTitle = "Root Log Handler";
        public const string SupplierTitle = "GetARoom Hotel Search";
        public const string UnmappedTitle = "UnMapped Errors HotelSearch";
        
        // Profiling Constants
        public const string Profiling = "Profiling";
        public const string ProfilingTitle = "Root Log Handler";

        // SearchResponse Constants
        public const string xmlHeader = "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"";
        public const string xsiNil = "xsi:nil=\"true\"";
        public const string emptyString = "";
        public const string emptySpace = " ";
        public const string colon = ": ";
        public const string dateFormat = "MM/dd/yyyy";
        public const string resortFeeName = "(Total Fee: ";
        public const string freeCancellation = "free_cancellation";
        public const string freeParking = "free_parking";
        public const string freeInternet = "free_internet";
        public const string freeBreakfast = "free_breakfast";
        public const string freeDinner = "free_dinner";
        public const string freeLunch = "free_lunch";
        public const string allInclusive = "all_inclusive";
        public const string boardBasisCode = "0";
        public const string closingBracket = ")";
        public const string currencyText = "All in ";
        public const string NonSmokeWithSpace = "non smok";
        public const string NonSmokeWithOutSpace = "nonsmok";
        public const string NonSmokeWithDash = "non-smok";
        public const string Smoke = "smok";
        public const string ErrorCategoryWarning = "Warning";

        // SearchRequest Constants
        public const string api = "api/";
        public const string room_availability = "/room_availability?";
        public const string check_in = "check_in=";
        public const string check_out = "&check_out=";
        public const string cancellation_rules = "&cancellation_rules=";
        public const string api_key = "&api_key=";
        public const string auth_token = "&auth_token=";
        public const string rinfo = "&rinfo=";
        public const string openSquareBracket = "[";
        public const string adultAge = "18,";
        public const string closeSquareBracket = "]";
        public const string transaction_id = "&transaction_id=";
        public const string propertyId = "property_id[]=";
        public const string andSymbol = "&";

        // HTTP Client Constants
        public const string gzip = "application/gzip";
        public const string applicationXwwwFormUrlencoded = "application/x-www-form-urlencoded";

        //ConnectorError Constants
        public const string ErrorCodePrefix = "ErrorCode";
        public const string ErrorMappingFilePath = "SupplierUsgErrorMap.json";

        // USG Constants
        public const string InvalidRequest = "5";
        public const string ValidationErrors = "55";
        public const string EmptyCriteria = "327";
        public const string EmptySupplier = "18";
        public const string EmptyCheckin = "471";
        public const string CheckoutBeforeCheckin = "25";
        public const string MinOneDayDifference = "326";
        public const string MaxStayExceed = "35";
        public const string EmptySearchPattern = "447";
        public const string MaxOccupancy = "325";
        public const string EmptyOccupancy = "27";
        public const string MinOneAdult = "31";
        public const string MaxChildAge = "43";
        public const string MaxGuestsPerRoom = "129";
        public const string EmptySupplierId = "19";
        public const string EmptySupplierName = "20";
        public const string EmptyConfiguration = "21";
        public const string EmptyUserId = "22";
        public const string EmptyPassword = "22";
        public const string UnSupportedCurrency = "3";
        public const string PastCheckinDate = "23";
        public const string CorelationIdHeaderRequired = "497";
        public const string AcceptLanguageInvalid = "117";
        public const string NoResultsFound = "13";
        public const string InvalidCountryCode = "92";
        public const string TenantIdRequired = "251";
        public const string UserTokenRequired = "51";
        public const string MaxGuestsPerBooking = "470";

        // MapError Constants
        public const string MinAllowedChildAge = "0";
        public const string CheckInDate = "check-in date";
        public const string CheckOutDate = "check-out date";
        public const string SupplierConfigurationUserId = "userId";
        public const string SupplierConfigurationPassword = "password";

        public const string ResponseContentType = "application/json";
        public const string OptionalFieldAll = "all";
        public const string CancellationRulesTrue = "1";
        public const string CancellationRulesFalse = "0";

        public const string CountryCodeMappingFilePath = "CountryCodeMap.json";

        // Configuration Constants
        public const string ConfigurationSettingName = "configurationsetting";
        public const int CacheTimeoutInSeconds = 1000;
        public const string UsgErrorCodeForUnmapped = "620";
        public const string ApiVersion = "1.1";

        // CacheKeys
        public const string ConfigurationSettings = "configurationsetting";
        public const string ServiceMetadata = "servicemetadata";
    }

}
