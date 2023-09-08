
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentPackageType
    {
        string Code { get; }
    }
    public class FreightRateShopShipmentPackageType : IFreightRateShopShipmentPackageType
    {
        public FreightRateShopShipmentPackageType(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
