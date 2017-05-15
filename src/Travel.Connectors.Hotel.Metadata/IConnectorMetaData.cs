using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Connectors.Hotel.Metadata.Models;

namespace Travel.Connectors.Hotel.Metadata
{
    public interface IConnectorMetadata
    {
        MetadataResponse ReadMetaData();
    }
}
