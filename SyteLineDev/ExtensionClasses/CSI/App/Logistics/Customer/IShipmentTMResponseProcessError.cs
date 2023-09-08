namespace CSI.Logistics.Customer
{
    public interface IShipmentTMResponseProcessError
    {
        string ErrorCode { get; }
        string ErrorMessage { get; }
        int ErrorSeverity { get; }
        int ErrorStatus { get; }
    }
}