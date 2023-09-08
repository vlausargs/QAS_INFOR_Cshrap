using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseCostAllocationCharge : IShipmentTMResponseCostAllocationCharge
    {
        public ShipmentTMResponseCostAllocationCharge(
            decimal amount,
            string chargeCode
        )
        {
            this.Amount = amount;
            this.ChargeCode = chargeCode;
        }

        public decimal Amount { get; }
        public string ChargeCode { get; }
    }
}
