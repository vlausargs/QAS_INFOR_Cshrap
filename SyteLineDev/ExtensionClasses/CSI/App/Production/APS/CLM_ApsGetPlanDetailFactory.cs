//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetPlanDetailFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetPlanDetailFactory
	{
		public ICLM_ApsGetPlanDetail Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetPlanDetail = new Production.APS.CLM_ApsGetPlanDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetPlanDetailExt = timerfactory.Create<Production.APS.ICLM_ApsGetPlanDetail>(_CLM_ApsGetPlanDetail);
			
			return iCLM_ApsGetPlanDetailExt;
		}
	}
}
