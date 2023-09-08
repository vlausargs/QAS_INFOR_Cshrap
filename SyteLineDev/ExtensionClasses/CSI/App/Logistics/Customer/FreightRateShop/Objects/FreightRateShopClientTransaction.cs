
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopClientTransaction
    {
        string ReferenceNumber { get; }
        string SourceSystem { get; }
    }
    public class FreightRateShopClientTransaction : IFreightRateShopClientTransaction
    {
        public FreightRateShopClientTransaction(string referenceNumber, string sourceSystem)
        {
            ReferenceNumber = referenceNumber;
            SourceSystem = sourceSystem;
        }

        public string ReferenceNumber { get; }
        public string SourceSystem { get; }

    }
}
