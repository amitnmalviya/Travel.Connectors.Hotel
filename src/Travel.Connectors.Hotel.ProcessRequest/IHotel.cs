using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Entities;

namespace Travel.Connectors.Hotel.ProcessRequest
{
    public interface IHotel
    {
        USGSearchResponse SearchHotels(USGSearchRequest usgSearchRequest, HttpRequest request);
    }
}
