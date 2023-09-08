using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentManager
    {
        void AddIFreightRateShopShipmentPackages(IFreightRateShopShipmentPackages _packages);
        void AddIFreightRateShopShipmentCommodities(IFreightRateShopShipmentCommodities _commodities);
        void ClearFreightRateShopShipmentPackages();
        void ClearFreightRateShopShipmentCommodities();
        IFreightRateShopShipmentOrigin CreateFreightRateShopShipmentOrigin(IFreightRateShopShipmentAddress _address);
        IFreightRateShopShipmentDestination CreateFreightRateShopShipmentDestination(IFreightRateShopShipmentAddress _address);
        IFreightRateShopShipmentPickupDateTime CreateFreightRateShopShipmentPickupDateTime(string _date, string _time);
        IFreightRateShopShipmentUOM CreateFreightRateShopShipmentTotalWeight(string _uom, decimal _value);
        IFreightRateShopShipmentPackages CreateFreightRateShopShipmentPackages(IFreightRateShopShipmentPackageType _packagingtype, IFreightRateShopShipmentPackageDimensions _dimensions, IFreightRateShopShipmentUOM _packageweight, int _numberofpieces);
        IFreightRateShopShipmentUOM CreateFreightRateShopShipmentTotalQuantity(string _uom, decimal _value);
        IFreightRateShopShipmentCommodities CreateFreightRateShopShipmentCommodities(int _sequence, string _code, string _classCode, IFreightRateShopShipmentUOM _weight, IFreightRateShopShipmentUOM _quantity);
        IFreightRateShopShipment GetFreightRateShopShipment(IFreightRateShopShipmentOrigin _origin, IFreightRateShopShipmentDestination _destination, IFreightRateShopShipmentPickupDateTime _pickupDateTime, IFreightRateShopShipmentUOM _shipmentTotalWeight, IFreightRateShopShipmentUOM _totalQuantity);
        IFreightRateShopShipmentAddress CreateFreightRateShopShipmentAddress(string _pOBox, string _streetNumber, string _addressLine1, string _addressLine2, string _addressLine3, string _city, string _stateProvinceCode, string _postalCode, string _countryCode);

    }
    public class FreightRateShopShipmentManager : IFreightRateShopShipmentManager
    {
        IList<IFreightRateShopShipmentPackages> PackageList;
        IList<IFreightRateShopShipmentCommodities> CommodityList;
        public FreightRateShopShipmentManager()
        {
            PackageList = new List<IFreightRateShopShipmentPackages>();
            CommodityList = new List<IFreightRateShopShipmentCommodities>();
        }
        void IFreightRateShopShipmentManager.AddIFreightRateShopShipmentPackages(IFreightRateShopShipmentPackages _packages)
        {
            PackageList.Add(_packages);
        }

        void IFreightRateShopShipmentManager.AddIFreightRateShopShipmentCommodities(IFreightRateShopShipmentCommodities _commodities)
        {
            CommodityList.Add(_commodities);
        }

        void IFreightRateShopShipmentManager.ClearFreightRateShopShipmentPackages()
        {
            PackageList.Clear();
        }

        void IFreightRateShopShipmentManager.ClearFreightRateShopShipmentCommodities()
        {
            CommodityList.Clear();
        }
        IFreightRateShopShipmentOrigin IFreightRateShopShipmentManager.CreateFreightRateShopShipmentOrigin(IFreightRateShopShipmentAddress _address)
        {
            return new FreightRateShopShipmentOrigin(_address);
        }
        IFreightRateShopShipmentDestination IFreightRateShopShipmentManager.CreateFreightRateShopShipmentDestination(IFreightRateShopShipmentAddress _address)
        {
            return new FreightRateShopShipmentDestination(_address);
        }

        IFreightRateShopShipmentPickupDateTime IFreightRateShopShipmentManager.CreateFreightRateShopShipmentPickupDateTime(string _date,string _time)
        {
            return new FreightRateShopShipmentPickupDateTime(_date, _time);
        }
        IFreightRateShopShipmentUOM IFreightRateShopShipmentManager.CreateFreightRateShopShipmentTotalWeight(string _uom, decimal _value)
        {
            return new FreightRateShopShipmentUOM(_uom, _value);
        }
        IFreightRateShopShipmentPackages IFreightRateShopShipmentManager.CreateFreightRateShopShipmentPackages(IFreightRateShopShipmentPackageType _packagingtype, IFreightRateShopShipmentPackageDimensions _dimensions, IFreightRateShopShipmentUOM _packageweight, int _numberofpieces)
        {
            return new FreightRateShopShipmentPackages(_packagingtype, _dimensions, _packageweight, _numberofpieces);
        }

        IFreightRateShopShipmentUOM IFreightRateShopShipmentManager.CreateFreightRateShopShipmentTotalQuantity(string _uom, decimal _value)
        {
            return new FreightRateShopShipmentUOM(_uom, _value);
        }
        IFreightRateShopShipmentCommodities IFreightRateShopShipmentManager.CreateFreightRateShopShipmentCommodities(int _sequence, string _code, string _classCode, IFreightRateShopShipmentUOM _weight,  IFreightRateShopShipmentUOM _quantity)
        {
            return new FreightRateShopShipmentCommodities(_sequence, _code, _classCode, _weight,  _quantity);
        }

        IFreightRateShopShipment IFreightRateShopShipmentManager.GetFreightRateShopShipment(IFreightRateShopShipmentOrigin _origin, IFreightRateShopShipmentDestination _destination, IFreightRateShopShipmentPickupDateTime _pickupDateTime, IFreightRateShopShipmentUOM _shipmentTotalWeight,  IFreightRateShopShipmentUOM _totalQuantity)
        {
            return new FreightRateShopShipment(_origin, _destination, _pickupDateTime, _shipmentTotalWeight, PackageList, _totalQuantity, CommodityList);
        }

        IFreightRateShopShipmentAddress IFreightRateShopShipmentManager.CreateFreightRateShopShipmentAddress(string _pOBox, string _streetNumber, string _addressLine1, string _addressLine2, string _addressLine3, string _city, string _stateProvinceCode, string _postalCode, string _countryCode)
        {
            return new FreightRateShopShipmentAddress(_pOBox, _streetNumber, _addressLine1, _addressLine2, _addressLine3, _city, _stateProvinceCode, _postalCode, _countryCode);
        }

        
    }
}
