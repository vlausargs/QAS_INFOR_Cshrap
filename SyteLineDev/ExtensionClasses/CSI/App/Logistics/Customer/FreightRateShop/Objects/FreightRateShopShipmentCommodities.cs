
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentCommodities
    {
        int Sequence { get; }
        string Code { get; }
        string ClassCode { get; }
        IFreightRateShopShipmentUOM Quantity { get; }
    }
    public class FreightRateShopShipmentCommodities : IFreightRateShopShipmentCommodities
    {
        public FreightRateShopShipmentCommodities(int sequence, string code, string classCode, IFreightRateShopShipmentUOM weight, IFreightRateShopShipmentUOM quantity)
        {
            Sequence = sequence;
            Code = code;
            ClassCode = classCode;
            Weight = weight;
            Quantity = quantity;
        }

        public int Sequence { get; }

        public string Code { get; }

        public string ClassCode { get; }

        public IFreightRateShopShipmentUOM Weight { get; }

        public IFreightRateShopShipmentUOM Quantity { get; }
    }
}
