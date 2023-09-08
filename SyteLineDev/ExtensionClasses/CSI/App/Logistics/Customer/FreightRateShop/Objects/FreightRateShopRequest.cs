
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopRequest
    {
        string[] ChargeTypes { get; }
        string[] EquipmentTypes { get; }
        string[] Modes { get; }
        string MovementDirection { get; }
        string RateOwner { get; }
        string RateType { get; }
        string[] CarrierCodes { get; }
        IFreightRateShopShipment Shipment { get; }
        string TripType { get; }
        IFreightRateShopClientTransaction ClientTransaction { get; }
    }
    public class FreightRateShopRequest : IFreightRateShopRequest
    {
        public FreightRateShopRequest
        (
            string rateOwner,
            string[] carrierCodes,
            string[] modes,
            string[] equipmentTypes,
            string tripType,
            string movementDirection,
            string rateType,
            string[] chargeTypes,
            IFreightRateShopShipment shipment,
            IFreightRateShopClientTransaction clientTransaction
        )
        {
            RateOwner = rateOwner;
            CarrierCodes = carrierCodes;
            Modes = modes;
            EquipmentTypes = equipmentTypes;
            TripType = tripType;
            MovementDirection = movementDirection;
            RateType = rateType;
            ChargeTypes = chargeTypes;
            Shipment = shipment;
            ClientTransaction = clientTransaction;
        }

        public FreightRateShopRequest
        (
            string rateOwner,
            string[] carrierCodes,
            string[] modes,
            string[] equipmentTypes,
            string tripType,
            string movementDirection,
            string rateType,
            IFreightRateShopShipment shipment,
            IFreightRateShopClientTransaction clientTransaction
        )
        {
            RateOwner = rateOwner;
            CarrierCodes = carrierCodes;
            Modes = modes;
            EquipmentTypes = equipmentTypes;
            TripType = tripType;
            MovementDirection = movementDirection;
            RateType = rateType;
            Shipment = shipment;
            ClientTransaction = clientTransaction;
        }

        public string RateOwner { get; }
        public string[] CarrierCodes { get; }
        public string[] Modes { get; }
        public string[] EquipmentTypes { get; }
        public string TripType { get; }
        public string MovementDirection { get; }
        public string RateType { get; }
        public string[] ChargeTypes { get; }
        public IFreightRateShopShipment Shipment { get; }
        public IFreightRateShopClientTransaction ClientTransaction { get; }
    }
}
