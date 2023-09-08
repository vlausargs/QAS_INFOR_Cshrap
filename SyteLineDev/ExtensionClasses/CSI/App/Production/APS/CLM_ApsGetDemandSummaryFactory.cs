//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetDemandSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetDemandSummaryFactory
	{
		public ICLM_ApsGetDemandSummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetDemandSummary = new Production.APS.CLM_ApsGetDemandSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetDemandSummaryExt = timerfactory.Create<Production.APS.ICLM_ApsGetDemandSummary>(_CLM_ApsGetDemandSummary);
			
			return iCLM_ApsGetDemandSummaryExt;
		}
	}
}
