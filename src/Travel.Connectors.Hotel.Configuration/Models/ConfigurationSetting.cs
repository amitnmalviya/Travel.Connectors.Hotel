using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Configuration.Models
{
    public class ConfigurationSetting
    {
        public ApplicationSettings applicationsettings { get; set; }
        public GetARoomSettings getaroomsettings { get; set; }
    }
}
