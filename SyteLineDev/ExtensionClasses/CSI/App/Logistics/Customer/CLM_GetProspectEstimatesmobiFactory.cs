//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetProspectEstimatesmobiFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetProspectEstimatesmobiFactory
	{
		public ICLM_GetProspectEstimatesmobi Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetProspectEstimatesmobi = new Logistics.Customer.CLM_GetProspectEstimatesmobi(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetProspectEstimatesmobiExt = timerfactory.Create<Logistics.Customer.ICLM_GetProspectEstimatesmobi>(_CLM_GetProspectEstimatesmobi);
			
			return iCLM_GetProspectEstimatesmobiExt;
		}
	}
}
