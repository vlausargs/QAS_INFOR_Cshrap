using System.Collections.Generic;
using Newtonsoft.Json;
using CSI.Serializer;

namespace CSI.Logistics.Customer
{
   public class ShipmentTMResponseRateResponse: IShipmentTMResponseRateResponse
    {
        public ShipmentTMResponseRateResponse(string carrierCode, 
            string carrierName, 
            IList<IShipmentTMResponseCharge> charges, 
            string currency, 
            string equipment, 
            int rateNumber, 
            string serviceLevel, 
            string serviceLevelCode, 
            string status, 
            decimal totalAmount, 
            int transitDays)
        {
            CarrierCode = carrierCode;
            CarrierName = carrierName;
            Charges = charges;
            Currency = currency;
            Equipment = equipment;
            RateNumber = rateNumber;
            ServiceLevel = serviceLevel;
            ServiceLevelCode = serviceLevelCode;
            Status = status;
            TotalAmount = totalAmount;
            TransitDays = transitDays;
        }

        public string CarrierCode { get; }
        public string CarrierName { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseCharge>, ShipmentTMResponseCharge, IShipmentTMResponseCharge>))]
        public IList<IShipmentTMResponseCharge> Charges { get; }
        public string Currency { get; }
        public string Equipment { get; }
        public int RateNumber { get; }
        public string ServiceLevel { get; }
        public string ServiceLevelCode { get; }
        public string Status { get; }
        public decimal TotalAmount { get; }
        public int TransitDays { get; }
    }
}
