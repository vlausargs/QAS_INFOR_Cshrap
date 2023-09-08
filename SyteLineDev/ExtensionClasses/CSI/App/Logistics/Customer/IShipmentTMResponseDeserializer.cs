//PROJECT NAME: Logistics.Tests
//CLASS NAME: ShipmentTMResponseDeserializerTest.cs

namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseDeserializer
    {
        (int? ReturnCode,string InfoBar,IShipmentTMResponseHeader ShipmentTMResponseHeader) Deserialize(string jsonString);
    }
}