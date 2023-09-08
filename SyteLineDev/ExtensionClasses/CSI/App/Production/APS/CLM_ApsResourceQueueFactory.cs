//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsResourceQueueFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsResourceQueueFactory
	{
		public ICLM_ApsResourceQueue Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsResourceQueue = new Production.APS.CLM_ApsResourceQueue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsResourceQueueExt = timerfactory.Create<Production.APS.ICLM_ApsResourceQueue>(_CLM_ApsResourceQueue);
			
			return iCLM_ApsResourceQueueExt;
		}
	}
}
