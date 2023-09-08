namespace CSI.Logistics.Customer
{
    public interface IUpdateShipmentWithTMInfo
    {
        (int? returnCode, string infobar) Process(string tMShipmentInfo);
    }
}