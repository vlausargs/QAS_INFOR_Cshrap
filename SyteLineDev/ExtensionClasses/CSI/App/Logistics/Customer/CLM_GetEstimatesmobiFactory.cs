//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetEstimatesmobiFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetEstimatesmobiFactory
	{
		public ICLM_GetEstimatesmobi Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetEstimatesmobi = new Logistics.Customer.CLM_GetEstimatesmobi(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetEstimatesmobiExt = timerfactory.Create<Logistics.Customer.ICLM_GetEstimatesmobi>(_CLM_GetEstimatesmobi);
			
			return iCLM_GetEstimatesmobiExt;
		}
	}
}
