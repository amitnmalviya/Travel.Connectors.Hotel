using Microsoft.AspNetCore.Mvc;
using Travel.Connectors.Hotel.Entities;
using Microsoft.Extensions.Caching.Memory;
using Travel.Connectors.Hotel.ProcessRequest;
using Travel.Connectors.Hotel.Metadata;
using Travel.Connectors.Hotel.ErrorMapping;
using Tavisca.Platform.Common.Configurations;
using Tavisca.Platform.Common.Logging;
using System.Collections.Generic;
using Tavisca.Platform.Common.Profiling;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.HealthChecks;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Travel.Connectors.Hotel.Controllers
{
    [Route("api/GetARoom")]
    public class GetARoomController : Controller
    {
        private readonly IHotel _hotel = null;
        private readonly HealthCheck _healthCheck;
        public GetARoomController(IHotel hotel, HealthCheck healthCheck)
        {
            _hotel = hotel;
            _healthCheck = healthCheck;
        }

        [HttpPost]
        
        public IActionResult SearchHotels([FromBody] USGSearchRequest usgSearchRequest)
        {
            HttpRequest
            USGSearchResponse usgSearchResponse = null;
            usgSearchResponse = _hotel.SearchHotels(usgSearchRequest, Request);
            HttpContext.Response.StatusCode = usgSearchResponse.HttpStatusCode;
            return new ObjectResult(usgSearchResponse);
        }

        [HttpGet]
        [Route("Healthcheck")]
        public async Task<IActionResult> HealthCheck()
        {
            using (var profileScope = new ProfileContext($"Controller.Health"))
            {
                var healthStatus = await _healthCheck.GetStatusAsync();
                if (healthStatus.IsHealthy)
                    return Ok(healthStatus.SuccessMessages);
                return StatusCode((int)HttpStatusCode.InternalServerError, healthStatus);
            }
        }
    }
}

