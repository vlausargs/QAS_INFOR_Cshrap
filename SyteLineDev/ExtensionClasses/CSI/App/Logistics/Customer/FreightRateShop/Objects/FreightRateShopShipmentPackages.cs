
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentPackages
    {
        IFreightRateShopShipmentPackageDimensions Dimensions { get; }
        int NumberOfPieces { get; }
        IFreightRateShopShipmentUOM PackageWeight { get; }
        IFreightRateShopShipmentPackageType PackagingType { get; }
    }
    public class FreightRateShopShipmentPackages : IFreightRateShopShipmentPackages
    {
        public FreightRateShopShipmentPackages
        (
            IFreightRateShopShipmentPackageType packagingType,
            IFreightRateShopShipmentPackageDimensions dimensions,
            IFreightRateShopShipmentUOM packageWeight,
            int numberOfPieces
        )
        {
            PackagingType = packagingType;
            Dimensions = dimensions;
            PackageWeight = packageWeight;
            NumberOfPieces = numberOfPieces;
        }

        public IFreightRateShopShipmentPackageType PackagingType { get; }
        public IFreightRateShopShipmentPackageDimensions Dimensions { get; }
        public IFreightRateShopShipmentUOM PackageWeight { get; }
        public int NumberOfPieces { get; }
    }
}
