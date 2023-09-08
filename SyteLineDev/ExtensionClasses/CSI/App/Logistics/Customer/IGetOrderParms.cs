namespace CSI.Logistics.Customer
{
    public interface IGetOrderParms
    {
        (int? ReturnCode, int? OrderVerificationTemplate, int? OrderInvoiceTemplate, int? PackingSlipTemplate) GetOrderParmsSp(int? OrderVerificationTemplate, int? OrderInvoiceTemplate, int? PackingSlipTemplate = null);
    }
}