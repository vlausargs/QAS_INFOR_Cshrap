//PROJECT NAME: Logistics
//CLASS NAME: CLM_CreatePendingInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CreatePendingInvoiceFactory
	{
		public ICLM_CreatePendingInvoice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CreatePendingInvoice = new Logistics.Customer.CLM_CreatePendingInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CreatePendingInvoiceExt = timerfactory.Create<Logistics.Customer.ICLM_CreatePendingInvoice>(_CLM_CreatePendingInvoice);
			
			return iCLM_CreatePendingInvoiceExt;
		}
	}
}
