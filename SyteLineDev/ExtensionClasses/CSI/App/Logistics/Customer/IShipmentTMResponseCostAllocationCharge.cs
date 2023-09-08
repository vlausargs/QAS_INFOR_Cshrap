namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseCostAllocationCharge
    {
        decimal Amount { get; }
        string ChargeCode { get; }
    }
}