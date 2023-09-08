namespace CSI.Logistics.Customer
{
    public interface IUpdateShipUnitDetailsWithTMInfo
    {
        (int? returnCode, string infobar) Process(IShipmentTMResponseHeader shipmentTMResponseHeader);
    }
}