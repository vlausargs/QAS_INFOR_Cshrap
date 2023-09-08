
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentPackageInsuredAmount
    {
        string Currency { get; }
        decimal Value { get; }
    }
    public class FreightRateShopShipmentPackageInsuredAmount : IFreightRateShopShipmentPackageInsuredAmount
    {
        public FreightRateShopShipmentPackageInsuredAmount(string currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        public string Currency { get; }
        public decimal Value { get; }
    }
}
