using CSI.Serializer;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopResponse
    {
        IList<IFreightRateShopCustomException> Alerts { get; }
        IFreightRateShopClientTransaction ClientTransaction { get; }
        IList<IFreightRateShopCustomException> Errors { get; }
        IList<IFreightRateShopRateRecords> RateRecords { get; }
    }
    public class FreightRateShopResponse : IFreightRateShopResponse
    {
        public FreightRateShopResponse(IFreightRateShopClientTransaction clientTransaction, IList<IFreightRateShopCustomException> alerts, IList<IFreightRateShopCustomException> errors, IList<IFreightRateShopRateRecords> rateRecords)
        {
            ClientTransaction = clientTransaction;
            Alerts = alerts;
            Errors = errors;
            RateRecords = rateRecords;
        }

        [JsonConverter(typeof(ConcreteTypeConverter<FreightRateShopClientTransaction>))]
        public IFreightRateShopClientTransaction ClientTransaction { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IFreightRateShopCustomException>, FreightRateShopCustomException, IFreightRateShopCustomException>))]
        public IList<IFreightRateShopCustomException> Alerts { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IFreightRateShopCustomException>, FreightRateShopCustomException, IFreightRateShopCustomException>))]
        public IList<IFreightRateShopCustomException> Errors { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IFreightRateShopRateRecords>, FreightRateShopRateRecords, IFreightRateShopRateRecords>))]
        public IList<IFreightRateShopRateRecords> RateRecords { get; }

    }
}
