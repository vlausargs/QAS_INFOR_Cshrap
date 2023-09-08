//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileARInvoiceCDMFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileARInvoiceCDMFactory
	{
		public IProfileARInvoiceCDM Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileARInvoiceCDM = new Logistics.Customer.ProfileARInvoiceCDM(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileARInvoiceCDMExt = timerfactory.Create<Logistics.Customer.IProfileARInvoiceCDM>(_ProfileARInvoiceCDM);
			
			return iProfileARInvoiceCDMExt;
		}
	}
}
