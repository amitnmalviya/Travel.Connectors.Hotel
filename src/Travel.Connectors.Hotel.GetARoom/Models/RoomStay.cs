using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Connectors.Hotel.GetARoom.Models
{
    public class RoomStay
    {
        public Room room { get; set; }

        [XmlElement("commission-tier")]
        public string commissiontier { get; set; }

        public bool? refundable { get; set; }

        public bool sale { get; set; }

        [XmlElement("promotional-text")]
        public string promotionaltext { get; set; }

        [XmlElement("promotion-details")]
        public string promotiondetails { get; set; }

        [XmlElement("value-adds")]
        public ValueAdds valueadds { get; set; }

        public int roomsleft { get; set; }
        [XmlElement("rooms-left")]
        public string RoomsLeft
        {
            get
            {
                return roomsleft.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    roomsleft = int.Parse(value);
            }
        }

        ////timed-pressure-sell
        //// expires-at
        ////restrictions
        ////geo-restrictions

        public double lowestaverage { get; set; }
        [XmlElement("lowest-average")]
        public string LowestAverage
        {
            get
            {
                return lowestaverage.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    lowestaverage = double.Parse(value);
            }
        }

        [XmlElement("fees-collected-at-property")]
        public FeesCollectedAtProperty feesCollectedAtProperty { get; set; }

        [XmlElement("display-pricing")]
        public DisplayPricing displaypricing { get; set; }

        [XmlElement("booking-pricing")]
        public DisplayPricing bookingpricing { get; set; }

        [XmlElement("rate-plan-type")]
        public string rateplantype { get; set; }

        [XmlElement("rate-plan-code")]
        public string rateplancode { get; set; }

        //public DateTime cancellationDeadline { get; set; }

        //[XmlAnyElement("cancellation-deadline")]
        //public string CancellationDeadline
        //{
        //    get
        //    {
        //        return cancellationDeadline.ToString(ApplicationConstants.dateFormat);
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //            cancellationDeadline = DateTime.Parse(value);
        //    }
        //}

        //[XmlElement("cancellation-penalties")]
        //public CancellationPenalties cancellationpenalties { get; set; }

        [XmlElement("landing-url")]
        public string landingurl { get; set; }
    }
}
