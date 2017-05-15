using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.GetARoom
{
    public class RateTypeMapper
    {
        private static readonly Dictionary<string, string> _rateTypes = new Dictionary<string, string> {
            { "public","published" },
            { "opaque","opaque"},
            { "unpublished1","negotiated"},
            { "unpublished","negotiated"}
        };
        public static string GetRateType(string supplierRateType)
        {
            string rateType;
            if (_rateTypes.TryGetValue(supplierRateType, out rateType))
                return rateType;
            else
                return "negotiated";
        }
    }
}
