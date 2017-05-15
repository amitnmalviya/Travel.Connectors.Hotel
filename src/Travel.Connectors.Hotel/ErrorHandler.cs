using Tavisca.Platform.Common.Logging;
using System;
using Tavisca.Platform.Common.ExceptionManagement;

namespace Travel.Connectors.Hotel
{
    public class ErrorHandler : IErrorHandler
    {
        public ErrorHandler(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        private ILogWriter _logWriter;

        public bool HandleException(Exception ex, string policy, out Exception newException)
        {
            _logWriter.WriteAsync(ex.ToEntry()).GetAwaiter().GetResult();
            newException = null;
            return false;
        }
    }
}