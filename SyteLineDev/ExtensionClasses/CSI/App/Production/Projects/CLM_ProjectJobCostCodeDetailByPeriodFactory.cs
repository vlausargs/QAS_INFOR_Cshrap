//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_ProjectJobCostCodeDetailByPeriodFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_ProjectJobCostCodeDetailByPeriodFactory
	{
		public ICLM_ProjectJobCostCodeDetailByPeriod Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ProjectJobCostCodeDetailByPeriod = new Production.Projects.CLM_ProjectJobCostCodeDetailByPeriod(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProjectJobCostCodeDetailByPeriodExt = timerfactory.Create<Production.Projects.ICLM_ProjectJobCostCodeDetailByPeriod>(_CLM_ProjectJobCostCodeDetailByPeriod);
			
			return iCLM_ProjectJobCostCodeDetailByPeriodExt;
		}
	}
}
