using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseHeader
    {
        string OrderCode { get; }
        string OrganizationCode { get; }

        IList<IShipmentTMResponsePlan> Plans { get; }

        IList<IShipmentTMResponseProcessError> ProcessErrors { get; }
        string Status { get; }

        IList<IShipmentTMResponseOrderTracking> Trackings { get; }
    }
}