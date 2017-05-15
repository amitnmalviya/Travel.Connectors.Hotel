using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Travel.Connectors.Hotel.HealthChecks
{
    //public interface IHealthCheck
    //{
    //    Task<IHttpActionResult> GetStatusAsync();
    //}

    public class HealthStatus
    {
        public HealthStatus()
        {
            IsHealthy = true;
        }
        public bool IsHealthy { get; set; }
        public List<string> SuccessMessages { get; } = new List<string>();

        public List<string> ErrorMessages { get; } = new List<string>();
    }


}
