using CSI.Serializer;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopRateRecords
    {
        string CarrierCode { get; }
        string CarrierName { get; }
        string Mode { get; }
        string ServiceLevel { get; }
        string ServiceLevelCode { get; }
        IList<IFreightRateShopRateRecordCharges> Charges { get; }
        string DaysInTransit { get; }
        string Equipment { get; }
        string EstimatedArrivalDate { get; }
        decimal TotalRatedAmount { get; }
        string CurrencyCode { get; }
        IFreightRateShopShipmentUOM BilledWeight { get; }

    }
    public class FreightRateShopRateRecords : IFreightRateShopRateRecords
    {
        public FreightRateShopRateRecords(string carrierCode, string carrierName, string mode, string serviceLevel, string serviceLevelCode, IList<IFreightRateShopRateRecordCharges> charges, string daysInTransit, string equipment, string estimatedArrivalDate, decimal totalRatedAmount, string currencyCode, IFreightRateShopShipmentUOM billedWeight)
        {
            CarrierCode = carrierCode;
            CarrierName = carrierName;
            Mode = mode;
            ServiceLevel = serviceLevel;
            ServiceLevelCode = serviceLevelCode;
            Charges = charges;
            DaysInTransit = daysInTransit;
            Equipment = equipment;
            EstimatedArrivalDate = estimatedArrivalDate;
            TotalRatedAmount = totalRatedAmount;
            CurrencyCode = currencyCode;
            BilledWeight = billedWeight;
        }

        public string CarrierCode { get; }
        public string CarrierName { get; }
        public string Mode { get; }
        public string ServiceLevel { get; }
        public string ServiceLevelCode { get; }
        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IFreightRateShopRateRecordCharges>, FreightRateShopRateRecordCharges, IFreightRateShopRateRecordCharges>))]
        public IList<IFreightRateShopRateRecordCharges> Charges { get; }
        public string DaysInTransit { get; }
        public string Equipment { get; }
        public string EstimatedArrivalDate { get; }
        public decimal TotalRatedAmount { get; }
        public string CurrencyCode { get; }

        [JsonConverter(typeof(ConcreteTypeConverter<FreightRateShopShipmentUOM>))]
       public IFreightRateShopShipmentUOM BilledWeight { get; }


    }
}
