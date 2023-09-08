
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentCommodityCode
    {
        string Code { get; }
    }
    public class FreightRateShopShipmentCommodityCode : IFreightRateShopShipmentCommodityCode
    {
        public FreightRateShopShipmentCommodityCode(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
