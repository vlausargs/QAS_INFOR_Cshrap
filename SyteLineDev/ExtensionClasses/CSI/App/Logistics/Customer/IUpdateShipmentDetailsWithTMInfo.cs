using System;

namespace CSI.Logistics.Customer
{
    public interface IUpdateShipmentDetailsWithTMInfo
    {
        (int? returnCode, string infobar) Process(IShipmentTMResponseHeader shipmentTMResponseHeader);
    }
}