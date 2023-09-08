using System.Collections.Generic;
using Newtonsoft.Json;
using CSI.Serializer;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponsePlan : IShipmentTMResponsePlan
    {
        public ShipmentTMResponsePlan(
            int? orderPlanSequence,
            decimal? distance,
            string distanceUom,
            IList<IShipmentTMResponseRateResponse> rateResponses,
            IShipmentTMResponseRateResponse selectedRateResponse,
            IList<IShipmentTMResponseShipUnit> shipUnits,
            IList<IShipmentTMResponseCostAllocationCharge> costAllocationCharges
        )
        {
            this.OrderPlanSequence = orderPlanSequence;
            this.Distance = distance;
            this.DistanceUom = distanceUom;
            this.RateResponses = rateResponses;
            this.SelectedRateResponse = selectedRateResponse;
            this.ShipUnits = shipUnits;
            this.CostAllocationCharges = costAllocationCharges;
        }

        public int? OrderPlanSequence { get; }
        public decimal? Distance { get; }
        public string DistanceUom { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseRateResponse>, ShipmentTMResponseRateResponse, IShipmentTMResponseRateResponse>))]
        public IList<IShipmentTMResponseRateResponse> RateResponses { get; }

        [JsonConverter(typeof(ConcreteTypeConverter<ShipmentTMResponseRateResponse>))]
        public IShipmentTMResponseRateResponse SelectedRateResponse { get; }


        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseShipUnit>, ShipmentTMResponseShipUnit, IShipmentTMResponseShipUnit>))]
        public IList<IShipmentTMResponseShipUnit> ShipUnits { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseCostAllocationCharge>, ShipmentTMResponseCostAllocationCharge, IShipmentTMResponseCostAllocationCharge>))]
        public IList<IShipmentTMResponseCostAllocationCharge> CostAllocationCharges { get; }
    }
}
