using CSI.Data.CRUD;

namespace CSI.Logistics.Customer
{
    public interface ICLM_CashImpactGrid
    {
        (ICollectionLoadResponse Data, int? ReturnCode) CLM_CashImpactGridSp(string TransactionType = null, string FilterString = null);
    }
}