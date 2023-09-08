
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentCommoditySequence
    {
        int Sequence { get; }
    }
    public class FreightRateShopShipmentCommoditySequence : IFreightRateShopShipmentCommoditySequence
    {
        public int Sequence { get; }

        public FreightRateShopShipmentCommoditySequence(int sequence)
        {
            Sequence = sequence;
        }
    }
}
