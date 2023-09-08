//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_ProjectJobAccumulatedByPeriodFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_ProjectJobAccumulatedByPeriodFactory
	{
		public ICLM_ProjectJobAccumulatedByPeriod Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ProjectJobAccumulatedByPeriod = new Production.Projects.CLM_ProjectJobAccumulatedByPeriod(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProjectJobAccumulatedByPeriodExt = timerfactory.Create<Production.Projects.ICLM_ProjectJobAccumulatedByPeriod>(_CLM_ProjectJobAccumulatedByPeriod);
			
			return iCLM_ProjectJobAccumulatedByPeriodExt;
		}
	}
}
