
namespace Travel.Connectors.Hotel.Entities
{
    public interface IHotelProvider
    {
        USGSearchResponse SearchHotels(USGSearchRequest usgSearchRequest, CommonLogParameters commonParameters);
    }
}
