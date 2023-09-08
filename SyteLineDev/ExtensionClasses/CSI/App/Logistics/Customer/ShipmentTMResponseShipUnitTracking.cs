using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseShipUnitTracking: IShipmentTMResponseTracking
    {

        public ShipmentTMResponseShipUnitTracking(
        string trackingType,
        string trackingNumber
        )
        {
            this.TrackingType = trackingType;
            this.TrackingNumber = trackingNumber;
        }

        public string TrackingType { get; }
        public string TrackingNumber { get; }
    }
}
