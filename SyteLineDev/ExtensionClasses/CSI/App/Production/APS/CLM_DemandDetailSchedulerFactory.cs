//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_DemandDetailSchedulerFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_DemandDetailSchedulerFactory
	{
		public ICLM_DemandDetailScheduler Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DemandDetailScheduler = new Production.APS.CLM_DemandDetailScheduler(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DemandDetailSchedulerExt = timerfactory.Create<Production.APS.ICLM_DemandDetailScheduler>(_CLM_DemandDetailScheduler);
			
			return iCLM_DemandDetailSchedulerExt;
		}
	}
}
