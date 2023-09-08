namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseTracking
    {
        string TrackingNumber { get; }
        string TrackingType { get; }
    }
}