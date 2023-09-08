namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseOrderTracking : IShipmentTMResponseTracking
    {
        string OrderId { get; }
        string OrderTrackingId { get; }
    }
}
