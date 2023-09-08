using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseRateResponse
    {
        string CarrierCode { get; }
        string CarrierName { get; }
        IList<IShipmentTMResponseCharge> Charges { get; }
        string Currency { get; }
        string Equipment { get; }
        int RateNumber { get; }
        string ServiceLevel { get; }
        string ServiceLevelCode { get; }
        string Status { get; }
        decimal TotalAmount { get; }
        int TransitDays { get; }
    }
}