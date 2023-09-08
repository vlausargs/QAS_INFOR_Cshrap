
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentCommodityManager
    {
        IFreightRateShopShipmentCommodities GetFreightRateShopShipmentCommodity(int _sequence, string _code, string _classCode, string _volumeUOM, decimal _volumeValue, string _quantityUOM, decimal _quantityValue);
    }
    public class FreightRateShopShipmentCommodityManager : IFreightRateShopShipmentCommodityManager
    {


        public FreightRateShopShipmentCommodityManager()
        {
        }

        IFreightRateShopShipmentCommodities IFreightRateShopShipmentCommodityManager.GetFreightRateShopShipmentCommodity(int _sequence, string _code, string _classCode, string _weightUOM, decimal _weightValue, string _quantityUOM, decimal _quantityValue)
        {
            var _commodityWeight = new FreightRateShopShipmentUOM(_weightUOM, _weightValue);
            var _commodityQuantity = new FreightRateShopShipmentUOM(_quantityUOM, _quantityValue);

            return new FreightRateShopShipmentCommodities(_sequence, _code, _classCode, _commodityWeight,  _commodityQuantity);
        }
    }
}
