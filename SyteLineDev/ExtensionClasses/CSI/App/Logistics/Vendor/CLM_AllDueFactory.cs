//PROJECT NAME: Logistics
//CLASS NAME: CLM_AllDueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_AllDueFactory
	{
		public ICLM_AllDue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_AllDue = new Logistics.Vendor.CLM_AllDue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_AllDueExt = timerfactory.Create<Logistics.Vendor.ICLM_AllDue>(_CLM_AllDue);
			
			return iCLM_AllDueExt;
		}
	}
}
