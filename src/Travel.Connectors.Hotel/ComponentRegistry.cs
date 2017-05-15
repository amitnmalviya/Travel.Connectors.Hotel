using StructureMap;
using Tavisca.Platform.Common.Logging;
using Travel.Connectors.Hotel.Entities;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.GetARoom;
using Travel.Connectors.Hotel.Metadata;
using Travel.Connectors.Hotel.ProcessRequest;
using System;
using Tavisca.Platform.Common.ExceptionManagement;

namespace Travel.Connectors.Hotel
{
    //public class ComponentRegistry : Registry
    public class ComponentRegistry : Registry
    {
        public ComponentRegistry()
        {
            var islocal = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local");
            For<IHotel>().Use<ProcessRequest.Hotel>();
#if !Tavisca
            For(typeof(Tavisca.Platform.Common.Configurations.IConfigurationProvider)).Use(typeof(Travel.Connectors.Hotel.Configuration.FileConfiguration));
            For(typeof(ILogWriter)).Use(typeof(Travel.Connectors.Hotel.Logger.FileLogger));
#else
            For<Tavisca.Platform.Common.Configurations.IConfigurationProvider>().Use(c => new Tavisca.Common.Plugins.Configuration.ConfigurationProvider("connector_hotels"));
            For<ILogWriter>().Use<Tavisca.Common.Plugins.Logging.LogWriter>();
            For<Tavisca.Frameworks.Logging.Configuration.IApplicationLogSettings>().Use<Tavisca.Frameworks.Logging.Configuration.ApplicationLogSection>();
#endif
            For<IConnectorMetadata>().Use<ServiceBasedMetadata>();
            For<IConnectorError>().Use<ConnectorError>();
            For<IHotelProvider>().Use<GetARoomProvider>();
            For<IErrorHandler>().Use<ErrorHandler>();
        }
    }
}
