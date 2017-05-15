using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web;
//using Tavisca.Frameworks.Session.Provider.AeroSpike;
//using Tavisca.USG.Common.Logging;
//using Tavisca.USG.Hotels.Dependencies;
using Tavisca.Platform.Common.Configurations;
using Tavisca.Platform.Common.Context;
using Tavisca.Platform.Common.Logging;
using Travel.Connectors.Hotel.Controllers;

namespace Travel.Connectors.Hotel.HealthChecks
{
    public class HealthCheck //: IHealthCheck
    {
        public HealthCheck(IConfigurationProvider configurationProvider, ILogWriter logger)
        {
            ConfigurationProvider = configurationProvider;
            Logger = logger;
        }

        private IConfigurationProvider ConfigurationProvider { get; }
        private ILogWriter Logger { get; }

        public async Task<HealthStatus> GetStatusAsync()
        {
            var status = new HealthStatus();
            await GetConsulStatus(status);
            if (!status.IsHealthy)
            {
                LogFailure(status.ErrorMessages);
            }

            return (status);
        }

        private async Task GetConsulStatus(HealthStatus status)
        {
            try
            {
                var value = await ConfigurationProvider.GetGlobalConfigurationAsStringAsync("shared", "health_check", "healthy");
                if (value == "true")
                {
                    status.IsHealthy = status.IsHealthy && true;
                    status.SuccessMessages.Add($"connector_hotels ConsulStatus : Success ");
                }
                else
                {
                    status.IsHealthy = false;
                    var msg = $"connector_hotels ConsulStatus : Failed | Message : Could not connect to consul";
                    status.ErrorMessages.Add(msg);
                }
            }
            catch (Exception ex)
            {
                status.IsHealthy = false;
                var msg = $"connector_hotels ConsulStatus : Failed | Message : {ex.Message}";
                status.ErrorMessages.Add(msg);
            }
        }
        private void LogFailure(List<string> message)
        {
            Logger.WriteAsync(new TransactionLogEntry()
            {
                MethodName = "Health-check",
                Title = "Health-check",
                Status = StatusOptions.Failure,
                ResponseObject = message,
                SerializerType = SerializerType.JsonNetSerializer,
            });
        }
    }
}