//PROJECT NAME: Production
//CLASS NAME: CLM_ResGanttPlanFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ResGanttPlanFactory
	{
		public ICLM_ResGanttPlan Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ResGanttPlan = new Production.APS.CLM_ResGanttPlan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResGanttPlanExt = timerfactory.Create<Production.APS.ICLM_ResGanttPlan>(_CLM_ResGanttPlan);
			
			return iCLM_ResGanttPlanExt;
		}
	}
}
