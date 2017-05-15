using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Logging;

namespace Travel.Connectors.Hotel.Logger
{
    public class RedisLogger : ILogWriter
    {
        public Task WriteAsync(LogEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
