using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class ValueAdds
    {
        [XmlElement("value-add")]
        public ValueAdd[] valueadd { get; set; }
    }

}
