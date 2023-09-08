using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseCharge : IShipmentTMResponseCharge
    {
        public ShipmentTMResponseCharge(
            string chargeCode,
            string chargeDescription,
            string currency,
            decimal amount
        )
        {
            this.ChargeCode = chargeCode;
            this.ChargeDescription = chargeDescription;
            this.Currency = currency;
            this.Amount = amount;
        }

        public string ChargeCode { get; }
        public string ChargeDescription { get; }
        public string Currency { get; }
        public decimal Amount { get; }
    }
}
