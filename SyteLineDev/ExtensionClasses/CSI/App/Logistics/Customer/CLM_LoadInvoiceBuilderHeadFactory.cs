//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_LoadInvoiceBuilderHeadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_LoadInvoiceBuilderHeadFactory
	{
		public ICLM_LoadInvoiceBuilderHead Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadInvoiceBuilderHead = new Logistics.Customer.CLM_LoadInvoiceBuilderHead(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadInvoiceBuilderHeadExt = timerfactory.Create<Logistics.Customer.ICLM_LoadInvoiceBuilderHead>(_CLM_LoadInvoiceBuilderHead);
			
			return iCLM_LoadInvoiceBuilderHeadExt;
		}
	}
}
