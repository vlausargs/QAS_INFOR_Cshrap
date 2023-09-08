
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopRateRecordCharges
    {
        string ChargeCode { get; }
        string ChargeDescription { get; }
        string CurrencyCode { get; }
        string DependantCharges { get; }
        decimal RatedAmount { get; }
        string RateId { get; }
        string ComputedInstance { get; }
    }
    public class FreightRateShopRateRecordCharges : IFreightRateShopRateRecordCharges
    {
        public FreightRateShopRateRecordCharges( string chargeDescription, string chargeCode, string currencyCode, decimal ratedAmount, string rateId, string dependantCharges, string computedInstance)
        {
            ChargeDescription = chargeDescription;
            ChargeCode = chargeCode;
            CurrencyCode = currencyCode;
            RatedAmount = ratedAmount;
            RateId = rateId;
            DependantCharges = dependantCharges;
            ComputedInstance = computedInstance;
        }


        public string ChargeDescription { get; }
        public string ChargeCode { get; }
        public string CurrencyCode { get; }
        public decimal RatedAmount { get; }
        public string RateId { get; }
        public string DependantCharges { get; }
        public string ComputedInstance { get; }
    }
}
