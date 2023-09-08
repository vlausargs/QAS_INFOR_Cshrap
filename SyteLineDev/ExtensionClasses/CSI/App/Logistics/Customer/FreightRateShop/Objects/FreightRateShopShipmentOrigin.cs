
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentOrigin
    {
        IFreightRateShopShipmentAddress Address { get; }
    }
    public class FreightRateShopShipmentOrigin : IFreightRateShopShipmentOrigin
    {
        public IFreightRateShopShipmentAddress Address { get; }

        public FreightRateShopShipmentOrigin(IFreightRateShopShipmentAddress address)
        {
            Address = address;
        }
    }
}
