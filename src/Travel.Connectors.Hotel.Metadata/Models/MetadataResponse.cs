using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Metadata.Models
{
    public class MetadataResponse
    {
        public string connectorIdentifier { get; set; }
        public string supplierFamily { get; set; }
        public string ipRestricted { get; set; }
        public string[] supportedCurrencies { get; set; }
        public int properties { get; set; }
        public string[] markets { get; set; }
        public string[] countriesSupported { get; set; }
        public StaticContent staticContent { get; set; }
        public string[] paymentMode { get; set; }
        public string[] merchantsOfRecord { get; set; }
        public string[] rateTypes { get; set; }
        public string[] inventoryTypes { get; set; }
        public string[] supportedCultures { get; set; }
        public int guestLimitForBooking { get; set; }
        public Multiroom multiroom { get; set; }
        public Verbs verbs { get; set; }
    }
}
