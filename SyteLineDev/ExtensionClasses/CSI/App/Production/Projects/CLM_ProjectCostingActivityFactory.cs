//PROJECT NAME: Production
//CLASS NAME: CLM_ProjectCostingActivityFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_ProjectCostingActivityFactory
	{
		public ICLM_ProjectCostingActivity Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ProjectCostingActivity = new Production.Projects.CLM_ProjectCostingActivity(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProjectCostingActivityExt = timerfactory.Create<Production.Projects.ICLM_ProjectCostingActivity>(_CLM_ProjectCostingActivity);
			
			return iCLM_ProjectCostingActivityExt;
		}
	}
}
