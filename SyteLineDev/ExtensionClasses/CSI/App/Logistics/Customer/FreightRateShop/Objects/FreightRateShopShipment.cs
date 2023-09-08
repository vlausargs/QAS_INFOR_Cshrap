using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipment
    {
        IFreightRateShopShipmentDestination Destination { get; }
        IFreightRateShopShipmentOrigin Origin { get; }
        IList<IFreightRateShopShipmentPackages> Packages { get; }
        IFreightRateShopShipmentPickupDateTime PickupDateTime { get; }
        IFreightRateShopShipmentUOM ShipmentTotalWeight { get; }
        IFreightRateShopShipmentUOM TotalQuantity { get; }
        IList<IFreightRateShopShipmentCommodities> Commodities { get; }
    }
    public class FreightRateShopShipment : IFreightRateShopShipment
    {
       public FreightRateShopShipment
       (
            IFreightRateShopShipmentOrigin origin,
            IFreightRateShopShipmentDestination destination,
            IFreightRateShopShipmentPickupDateTime pickupDateTime,
            IFreightRateShopShipmentUOM shipmentTotalWeight,
            IList<IFreightRateShopShipmentPackages> packages,
            IFreightRateShopShipmentUOM totalQuantity,
            IList<IFreightRateShopShipmentCommodities> commodities)
        {
            Origin = origin;
            Destination = destination;
            PickupDateTime = pickupDateTime;
            ShipmentTotalWeight = shipmentTotalWeight;
            Packages = packages;
            TotalQuantity = totalQuantity;
            Commodities = commodities;
        }
        public IFreightRateShopShipmentOrigin Origin { get; }
        public IFreightRateShopShipmentDestination Destination { get; }
        public IFreightRateShopShipmentPickupDateTime PickupDateTime { get; }
        public IFreightRateShopShipmentUOM ShipmentTotalWeight { get; }
        public IList<IFreightRateShopShipmentPackages> Packages { get; }
        public IFreightRateShopShipmentUOM TotalQuantity { get; }
        public IList<IFreightRateShopShipmentCommodities> Commodities { get; }
    }
}
