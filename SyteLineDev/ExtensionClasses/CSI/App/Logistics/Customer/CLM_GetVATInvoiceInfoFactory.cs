//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetVATInvoiceInfoFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetVATInvoiceInfoFactory
	{
		public ICLM_GetVATInvoiceInfo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetVATInvoiceInfo = new Logistics.Customer.CLM_GetVATInvoiceInfo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetVATInvoiceInfoExt = timerfactory.Create<Logistics.Customer.ICLM_GetVATInvoiceInfo>(_CLM_GetVATInvoiceInfo);
			
			return iCLM_GetVATInvoiceInfoExt;
		}
	}
}
