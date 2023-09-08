//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ResourceScheduleFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ResourceScheduleFactory
	{
		public ICLM_ResourceSchedule Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ResourceSchedule = new Production.APS.CLM_ResourceSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResourceScheduleExt = timerfactory.Create<Production.APS.ICLM_ResourceSchedule>(_CLM_ResourceSchedule);
			
			return iCLM_ResourceScheduleExt;
		}
	}
}
