//PROJECT NAME: Production
//CLASS NAME: CLM_ApsInventorySummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsInventorySummaryFactory
	{
		public ICLM_ApsInventorySummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsInventorySummary = new Production.APS.CLM_ApsInventorySummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsInventorySummaryExt = timerfactory.Create<Production.APS.ICLM_ApsInventorySummary>(_CLM_ApsInventorySummary);
			
			return iCLM_ApsInventorySummaryExt;
		}
	}
}
