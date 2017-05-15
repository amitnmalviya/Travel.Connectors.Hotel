
namespace Travel.Connectors.Hotel.Logger.Enum
{
    public enum LogCategory
    {
        SupplierTrace,
        USGTrace,
        UnMappedErrorTrace,
        ExceptionTrace,
        ProfilerTrace,
        Default
    }

    public enum ErrorType
    {
        BadRequestException,
        SystemException,
        ContentNotFoundException,
        CommunicationException,
        ConfigurationException,
        Failure
    }

    public enum Severity
    {
        Warning,
        Error,
        Critical,
        Undefined,
        Information,
        Verbose
    }
    public enum Priority
    {
        Undefined = 1,
        Low = 2,
        Medium = 3,
        High = 4
    }
}