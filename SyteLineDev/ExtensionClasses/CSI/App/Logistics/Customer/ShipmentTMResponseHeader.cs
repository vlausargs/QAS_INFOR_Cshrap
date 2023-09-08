using CSI.Serializer;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseHeader : IShipmentTMResponseHeader
    {
        public ShipmentTMResponseHeader(
            string orderCode,
            string organizationCode,
            string status,
            IList<IShipmentTMResponseOrderTracking> trackings,
            IList<IShipmentTMResponsePlan> plans,
            IList<IShipmentTMResponseProcessError> processErrors
        )
        {
            this.OrderCode = orderCode;
            this.OrganizationCode = organizationCode;
            this.Status = status;
            this.Trackings = trackings;
            this.Plans = plans;
            this.ProcessErrors = processErrors;
        }

        public string OrderCode { get; }
        public string OrganizationCode { get; }
        public string Status { get; }
        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseOrderTracking>, ShipmentTMResponseOrderTracking, IShipmentTMResponseOrderTracking>))]
        public IList<IShipmentTMResponseOrderTracking> Trackings { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponsePlan>, ShipmentTMResponsePlan, IShipmentTMResponsePlan>))]
        public IList<IShipmentTMResponsePlan> Plans { get; }

        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseProcessError>, ShipmentTMResponseProcessError, IShipmentTMResponseProcessError>))]
        public IList<IShipmentTMResponseProcessError> ProcessErrors { get; }
    }
}