//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ResourceGroupPlanFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ResourceGroupPlanFactory
	{
		public ICLM_ResourceGroupPlan Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ResourceGroupPlan = new Production.APS.CLM_ResourceGroupPlan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResourceGroupPlanExt = timerfactory.Create<Production.APS.ICLM_ResourceGroupPlan>(_CLM_ResourceGroupPlan);
			
			return iCLM_ResourceGroupPlanExt;
		}
	}
}
