namespace CSI.BusInterface.ESBExtWhse
{
    public interface IDocumentIDName
    {
        string GetDocIDName(string docIDName, string purchaseOrderRef, string salesOrderRef);
    }

    public class DocumentIDName : IDocumentIDName
    {
        public string GetDocIDName(string docIDName, string purchaseOrderRef, string salesOrderRef)
        {
            if (docIDName == null)
                docIDName = (!(purchaseOrderRef == null) ? "PurchaseOrder" : !(salesOrderRef == null) ? "SalesOrder" : "Transfer");
            return docIDName;
        }
    }
}
