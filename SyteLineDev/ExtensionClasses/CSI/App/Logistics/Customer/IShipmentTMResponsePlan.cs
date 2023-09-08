using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponsePlan
    {
        IList<IShipmentTMResponseCostAllocationCharge> CostAllocationCharges { get; }
        decimal? Distance { get; }
        string DistanceUom { get; }
        int? OrderPlanSequence { get; }
        IList<IShipmentTMResponseRateResponse> RateResponses { get; }
        IShipmentTMResponseRateResponse SelectedRateResponse { get; }
        IList<IShipmentTMResponseShipUnit> ShipUnits { get; }
    }
}