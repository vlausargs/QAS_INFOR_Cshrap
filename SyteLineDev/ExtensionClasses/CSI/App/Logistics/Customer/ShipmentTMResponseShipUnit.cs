using System.Collections.Generic;
using Newtonsoft.Json;
using CSI.Serializer;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseShipUnit : IShipmentTMResponseShipUnit
    {
        public ShipmentTMResponseShipUnit(
            int shipUnitSequence,
            IList<IShipmentTMResponseTracking> trackings
        )
        {
            this.ShipUnitSequence = shipUnitSequence;
            this.Trackings = trackings;
        }

        public int ShipUnitSequence { get; }
        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IShipmentTMResponseTracking>, ShipmentTMResponseShipUnitTracking, IShipmentTMResponseTracking>))]
        public IList<IShipmentTMResponseTracking> Trackings { get; }
    }

}
