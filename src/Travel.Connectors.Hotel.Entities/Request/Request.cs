using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Entities
{
    public class Request
    {
        public virtual ErrorInfo IsUSGSearchRequestValid(MetadataResponse metadataResponse, IConnectorError errrorProvider)
        {
            return null;
        }
    }
}
