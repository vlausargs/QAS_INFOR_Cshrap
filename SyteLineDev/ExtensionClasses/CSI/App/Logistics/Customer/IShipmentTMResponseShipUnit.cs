using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseShipUnit
    {
        int ShipUnitSequence { get; }

        IList<IShipmentTMResponseTracking> Trackings { get; }
    }
}