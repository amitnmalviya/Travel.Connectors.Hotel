using Travel.Connectors.Hotel.ErrorMapping.Models;

namespace Travel.Connectors.Hotel.ErrorMapping
{
    public interface IConnectorError
    {
        UsgError GetUsgError(string usgErrorCode);

        UsgError GetUsgMappedError(string supplieErrorCode);
    }
}
