//PROJECT NAME: Material
//CLASS NAME: CLM_PlanningDetailSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_PlanningDetailSummaryFactory
	{
		public ICLM_PlanningDetailSummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PlanningDetailSummary = new Material.CLM_PlanningDetailSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PlanningDetailSummaryExt = timerfactory.Create<Material.ICLM_PlanningDetailSummary>(_CLM_PlanningDetailSummary);
			
			return iCLM_PlanningDetailSummaryExt;
		}
	}
}
