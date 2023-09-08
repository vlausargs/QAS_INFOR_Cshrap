//PROJECT NAME: Logistics
//CLASS NAME: CLM_PurchasingFundsCommittedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchasingFundsCommittedFactory
	{
		public ICLM_PurchasingFundsCommitted Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PurchasingFundsCommitted = new Logistics.Vendor.CLM_PurchasingFundsCommitted(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PurchasingFundsCommittedExt = timerfactory.Create<Logistics.Vendor.ICLM_PurchasingFundsCommitted>(_CLM_PurchasingFundsCommitted);
			
			return iCLM_PurchasingFundsCommittedExt;
		}
	}
}
