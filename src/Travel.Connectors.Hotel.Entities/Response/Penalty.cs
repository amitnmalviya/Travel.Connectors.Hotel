using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Entities
{
    public class Penalty
    {
        public Window window { get; set; }
        public double supplierValue { get; set; }
        public SupplierValueType supplierValueType { get; set; }
        public double calculatedAmount { get; set; }
    }
}
