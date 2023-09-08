namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseOrderTracking : IShipmentTMResponseOrderTracking
    {
        public ShipmentTMResponseOrderTracking(
            string orderTrackingId,
            string orderId,
            string trackingType,
            string trackingNumber
        )
        {
            this.OrderTrackingId = orderTrackingId;
            this.OrderId = orderId;
            this.TrackingType = trackingType;
            this.TrackingNumber = trackingNumber;
        }
        public string OrderTrackingId { get; }
        public string OrderId { get; }
        public string TrackingType { get; }
        public string TrackingNumber { get; }
    }
}