using System.Collections.Generic;
using System.Linq;

namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopRequestManager
    {
        void AddFreightRateShopChargeTypes(IFreightRateShopChargeTypes chargeTypes);
        void AddFreightRateShopEquipmentTypes(IFreightRateShopEquipmentTypes equipmentTypes);
        void AddFreightRateShopModes(IFreightRateShopModes modes);
        void AddFreightRateShopCarrierCodes(IFreightRateShopCarrierCodes carrierCode);
        IFreightRateShopCarrierCodes CreateFreightRateShopCarrierCodes(string carrierCode);

        IFreightRateShopModes CreateFreightRateShopModes(string modes);

        IFreightRateShopEquipmentTypes CreateFreightRateShopEquipmentTypes(string equipmenttype);

        IFreightRateShopChargeTypes CreateFreightRateShopChargeTypes(string chargetype);

        IFreightRateShopShipment CreateFreightRateShopShipments(IFreightRateShopShipmentOrigin origin, IFreightRateShopShipmentDestination destination, IFreightRateShopShipmentPickupDateTime pickupDateTime, IFreightRateShopShipmentUOM shipmentTotalWeight, IList<IFreightRateShopShipmentPackages> packages, IFreightRateShopShipmentUOM totalQuantity, IList<IFreightRateShopShipmentCommodities> commodities);
        IFreightRateShopRequest GetFreightRateShopRequest(string RateOwner, string TripType, string MovementDirection, string RateType, string _referencenumber, string _sourcesystem, IFreightRateShopShipment shipment);

    }
    public class FreightRateShopRequestManager : IFreightRateShopRequestManager
    {

        IList<IFreightRateShopCarrierCodes> CarrierCodeList;
        IList<IFreightRateShopModes> ModeList;
        IList<IFreightRateShopEquipmentTypes> EquipmentTypeList;
        IList<IFreightRateShopChargeTypes> ChargeTypeList;

        public FreightRateShopRequestManager()
        {
            CarrierCodeList = new List<IFreightRateShopCarrierCodes>();
            ModeList = new List <IFreightRateShopModes>();
            EquipmentTypeList = new List<IFreightRateShopEquipmentTypes>();
            ChargeTypeList = new List<IFreightRateShopChargeTypes>();
        }

        void IFreightRateShopRequestManager.AddFreightRateShopCarrierCodes(IFreightRateShopCarrierCodes carrierCode)
        {
            CarrierCodeList.Add(carrierCode);
        }

        void IFreightRateShopRequestManager.AddFreightRateShopModes(IFreightRateShopModes modes)
        {
            ModeList.Add(modes);
        }

        void IFreightRateShopRequestManager.AddFreightRateShopEquipmentTypes(IFreightRateShopEquipmentTypes equipmentTypes)
        {
            EquipmentTypeList.Add(equipmentTypes);
        }

        void IFreightRateShopRequestManager.AddFreightRateShopChargeTypes(IFreightRateShopChargeTypes chargeTypes)
        {
            ChargeTypeList.Add(chargeTypes);
        }

        IFreightRateShopCarrierCodes IFreightRateShopRequestManager.CreateFreightRateShopCarrierCodes(string carrierCode)
        {
            return new FreightRateShopCarrierCodes(carrierCode);
        }
        IFreightRateShopModes IFreightRateShopRequestManager.CreateFreightRateShopModes(string _modes)
        {
            return new FreightRateShopModes(_modes);
        }
        IFreightRateShopEquipmentTypes IFreightRateShopRequestManager.CreateFreightRateShopEquipmentTypes(string _equipmenttype)
        {
            return new FreightRateShopEquipmentTypes(_equipmenttype);
        }
        IFreightRateShopChargeTypes IFreightRateShopRequestManager.CreateFreightRateShopChargeTypes(string _chargetype)
        {
            return new FreightRateShopChargeTypes(_chargetype);
        }
        IFreightRateShopShipment IFreightRateShopRequestManager.CreateFreightRateShopShipments(IFreightRateShopShipmentOrigin origin, IFreightRateShopShipmentDestination destination, IFreightRateShopShipmentPickupDateTime pickupDateTime, IFreightRateShopShipmentUOM shipmentTotalWeight, IList<IFreightRateShopShipmentPackages> packages, IFreightRateShopShipmentUOM totalQuantity, IList<IFreightRateShopShipmentCommodities> commodities)
        {
            return new FreightRateShopShipment(origin, destination, pickupDateTime, shipmentTotalWeight, packages, totalQuantity, commodities);
        }

        IFreightRateShopRequest IFreightRateShopRequestManager.GetFreightRateShopRequest(string RateOwner, string TripType, string MovementDirection, string RateType, string _referencenumber, string _sourcesystem, IFreightRateShopShipment shipment)
        {

            var CarrierCodesArray = CarrierCodeList.Select(x => x.CarrierCodes).ToArray();
            var modeListArray = ModeList.Select(x => x.Modes).ToArray();
            var EquipmentTypeArray = EquipmentTypeList.Select(x => x.EquipmentType).ToArray();

            var clientTransaction = new FreightRateShopClientTransaction(_referencenumber, _sourcesystem);
            return new FreightRateShopRequest(RateOwner, CarrierCodesArray, modeListArray, EquipmentTypeArray, TripType, MovementDirection, RateType, shipment, clientTransaction);
        }
    }
}
