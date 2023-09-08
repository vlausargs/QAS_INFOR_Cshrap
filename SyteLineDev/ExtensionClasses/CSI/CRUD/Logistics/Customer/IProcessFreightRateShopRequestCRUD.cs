namespace CSI.Logistics.Customer
{
    public interface IProcessFreightRateShopRequestCRUD
    {
        (string SuiteContext, string Path) GetFreightRateShopIONAPISuiteMethod(string suiteName, string methodName);
    }
}