using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Logging;
using Travel.Connectors.Hotel.Common.ErrorHandling;

namespace Travel.Connectors.Hotel
{
    public class ExceptionHandlerMiddleware
    {
        private ILogWriter _logWriter;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogWriter logWriter)
        {
            _logWriter = logWriter;
            _next = next;
        }

        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BadRequestException badRequestEx)
            {
                var err = ErrorInfo.FromBaseApplicationException(badRequestEx);
                httpContext.Response.StatusCode = (int)badRequestEx.HttpStatusCode;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(err, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator(), new InfoTranslator() } }));
            }
            catch (BaseApplicationException appEx)
            {               
                await _logWriter.WriteAsync(appEx.ToEntry());
                var err = ErrorInfo.FromBaseApplicationException(appEx);
                httpContext.Response.StatusCode = (int)appEx.HttpStatusCode;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(err, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator(), new InfoTranslator() } }));
            }
            catch (Exception ex)
            {
                await _logWriter.WriteAsync(ex.ToEntry());
                var err = ErrorInfo.InternalServerError();
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(err, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator(), new InfoTranslator() } }));
            }
        }      

        private static bool IsCriticalFault(BaseApplicationException appEx)
        {
            var isSystemException = appEx == null;
            var isCriticalAppException = appEx != null && (int)appEx.HttpStatusCode >= 500;
            return (isSystemException == true || isCriticalAppException == true);
        }
    }
}