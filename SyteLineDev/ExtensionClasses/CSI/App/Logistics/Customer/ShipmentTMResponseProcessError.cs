using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseProcessError : IShipmentTMResponseProcessError
    {
        public ShipmentTMResponseProcessError(
            string errorCode,
            string errorMessage,
            int errorSeverity,
            int errorStatus
        )
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.ErrorSeverity = errorSeverity;
            this.ErrorStatus = errorStatus;
        }

        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public int ErrorSeverity { get; }
        public int ErrorStatus { get; }
    }

}
