
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentPackageManager
    {
        IFreightRateShopShipmentPackageType CreateFreightRateShopShipmentPackageType(string code);
        IFreightRateShopShipmentPackageDimensions CreateFreightRateShopShipmentPackageDimensions(string uOM, decimal length, decimal width, decimal height);
        IFreightRateShopShipmentUOM CreateFreightRateShopShipmentPackageWeight(string uOM, decimal value);
        IFreightRateShopShipmentPackageInsuredAmount CreateFreightRateShopShipmentPackageInsuredAmount(string currency, decimal value);
        IFreightRateShopShipmentPackages GetFreightRateShopShipmentPackages(IFreightRateShopShipmentPackageType _packagingType, IFreightRateShopShipmentPackageDimensions _dimensions, int _numberOfPieces, IFreightRateShopShipmentUOM _packageWeight);
    }
    public class FreightRateShopShipmentPackageManager : IFreightRateShopShipmentPackageManager
    {
        public FreightRateShopShipmentPackageManager()
        { }
        IFreightRateShopShipmentPackageType IFreightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageType(string _code )
        {
            return new FreightRateShopShipmentPackageType(_code);
        }
        IFreightRateShopShipmentPackageDimensions IFreightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageDimensions(string _uOM, decimal _length, decimal _width, decimal _height)
        {
            return new FreightRateShopShipmentPackageDimensions(_uOM, _length, _width, _height);
        }
        IFreightRateShopShipmentUOM IFreightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageWeight(string _uOM, decimal _value)
        {
            return new FreightRateShopShipmentUOM(_uOM, _value);
        }
        IFreightRateShopShipmentPackageInsuredAmount IFreightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageInsuredAmount(string _currency, decimal _value)
        {
            return new FreightRateShopShipmentPackageInsuredAmount(_currency, _value);
        }

        public IFreightRateShopShipmentPackages GetFreightRateShopShipmentPackages(IFreightRateShopShipmentPackageType _packagingType, IFreightRateShopShipmentPackageDimensions _dimensions,  int _numberOfPieces, IFreightRateShopShipmentUOM _packageWeight)
        {
            return new FreightRateShopShipmentPackages(_packagingType, _dimensions, _packageWeight, _numberOfPieces);
        }
    }
}
