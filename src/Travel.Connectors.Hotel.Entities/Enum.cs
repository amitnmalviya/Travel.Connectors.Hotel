using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public enum SupplierValueType
    {
        amount,
        percent,
        nights
    }

    public enum InventoryTypes
    {
        perpaid,
        postpaid
    }

    public enum SmokingPreference
    {
        unknown,
        smoking,
        nonSmoking
    }
}
