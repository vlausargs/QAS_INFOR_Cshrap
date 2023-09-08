
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentDestination
    {
        IFreightRateShopShipmentAddress Address { get; }
    }
    public class FreightRateShopShipmentDestination : IFreightRateShopShipmentDestination
    {
        public IFreightRateShopShipmentAddress Address { get; }
       public FreightRateShopShipmentDestination(IFreightRateShopShipmentAddress address)
        {
            Address = address;
        }
    }
}
