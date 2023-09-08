using CSI.Serializer;
using System;

namespace CSI.Logistics.Customer
{
    public class ShipmentTMResponseDeserializer : IShipmentTMResponseDeserializer
    {
        ISerializerFactory serializerFactory;
        public ShipmentTMResponseDeserializer(ISerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory;
        }

        public (int? ReturnCode, string InfoBar, IShipmentTMResponseHeader ShipmentTMResponseHeader) Deserialize(string jsonString)
        {
            IShipmentTMResponseHeader ShipmentTMResponseHeader = null;
            int? ReturnCode = 0;
            string InfoBar = "";
            try
            {
                var serializer = serializerFactory.Create(SerializerType.NewtonConvert);

                ShipmentTMResponseHeader = serializer.Deserialize<ShipmentTMResponseHeader>(jsonString);
            }
            catch(Exception e)
            {
                InfoBar = e.Message;        
                ReturnCode = 16;
            }

            return (ReturnCode, InfoBar,ShipmentTMResponseHeader);
        }
    }
}