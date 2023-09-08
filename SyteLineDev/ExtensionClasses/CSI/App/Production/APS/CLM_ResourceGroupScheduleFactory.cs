//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ResourceGroupScheduleFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ResourceGroupScheduleFactory
	{
		public ICLM_ResourceGroupSchedule Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ResourceGroupSchedule = new Production.APS.CLM_ResourceGroupSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResourceGroupScheduleExt = timerfactory.Create<Production.APS.ICLM_ResourceGroupSchedule>(_CLM_ResourceGroupSchedule);
			
			return iCLM_ResourceGroupScheduleExt;
		}
	}
}
