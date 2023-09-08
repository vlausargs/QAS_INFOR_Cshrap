
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentUOM
    {
        string UOM { get; }
        decimal Value { get; }
    }
    public class FreightRateShopShipmentUOM : IFreightRateShopShipmentUOM
    {
        public FreightRateShopShipmentUOM(string uOM, decimal value)
        {
            UOM = uOM;
            Value = value;
        }

        public string UOM { get; }
        public decimal Value { get; }
    }
}
