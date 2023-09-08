
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentCommodityClassCode
    {
        string ClassCode { get; }
    }
    public class FreightRateShopShipmentCommodityClassCode : IFreightRateShopShipmentCommodityClassCode
    {
        public FreightRateShopShipmentCommodityClassCode(string classCode)
        {
            ClassCode = classCode;
        }

        public string ClassCode { get; }
    }
}
