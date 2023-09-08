namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseCharge
    {
        decimal Amount { get; }
        string ChargeCode { get; }
        string ChargeDescription { get; }
        string Currency { get; }
    }
}