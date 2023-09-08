
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopChargeTypes
    {
        string ChargeType { get; }
    }
    public class FreightRateShopChargeTypes : IFreightRateShopChargeTypes
    {
        public string ChargeType { get; }
        public FreightRateShopChargeTypes(string chargetype)
        {
            ChargeType = chargetype;
        }
    }
}
