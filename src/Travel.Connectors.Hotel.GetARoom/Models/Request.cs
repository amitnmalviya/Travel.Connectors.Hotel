using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class Request
    {
        private DateTime checkinDate { get; set; }
        [XmlElement("check-in")]
        public string Checkin
        {
            get
            {
                return checkinDate.ToString(ApplicationConstants.dateFormat);
            }
            set
            {
                checkinDate = DateTime.Parse(value);
            }
        }

        public DateTime checkoutDate { get; set; }
        [XmlElement("check-out")]
        // this redundant property has been added to de-seriliaze Checkout property when it's null is xml resposne  
        public string Checkout
        {
            get
            {
                return checkoutDate.ToString(ApplicationConstants.dateFormat);
            }
            set
            {
                checkoutDate = DateTime.Parse(value);
            }
        }

        public int rooms { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public string currency { get; set; }
    }
}
