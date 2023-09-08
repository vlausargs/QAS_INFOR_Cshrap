namespace CSI.Logistics.Customer
{
    public interface IShipmentOrderIdGenerator
    {
        T GenerateShipmentID<T>(string input, string delimiter);
    }
}