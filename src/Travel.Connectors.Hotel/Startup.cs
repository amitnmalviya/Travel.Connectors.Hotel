﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using StructureMap;
using Travel.Connectors.Hotel.ProcessRequest;
using System.IO;
using Tavisca.Platform.Common;
using Tavisca.Platform.Common.ExceptionManagement;

namespace Travel.Connectors.Hotel
{
    public class Startup
    {
        IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            // Add framework services.
            services.AddMvc()
                .AddControllersAsServices();

            var serviceProvider = ConfigureIoC(services);
            ExceptionPolicy.Configure(serviceProvider.GetRequiredService<IErrorHandler>());
            return serviceProvider;
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container(c =>
            {
                c.AddRegistry<ComponentRegistry>();
            });
            container.Configure(config =>
                        {
                            //Populate the container using the service collection
                            config.Populate(services);
                        });
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
            cultureInfo.DateTimeFormat = DateTimeFormatInfo.InvariantInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            app.UseMiddleware<ContextInjector>();
            app.UseMiddleware<ProfilerInjector>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ValidationMiddleware>();
            app.UseMvc();
        }
    }
}
