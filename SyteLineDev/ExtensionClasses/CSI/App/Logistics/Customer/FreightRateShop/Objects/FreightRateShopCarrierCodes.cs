
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopCarrierCodes
    {
        string CarrierCodes { get; }
    }
    public class FreightRateShopCarrierCodes : IFreightRateShopCarrierCodes
    {

       public string CarrierCodes { get; }

        public FreightRateShopCarrierCodes(string CarrierCodes)
        {
            this.CarrierCodes = CarrierCodes;
        }
    }
}
