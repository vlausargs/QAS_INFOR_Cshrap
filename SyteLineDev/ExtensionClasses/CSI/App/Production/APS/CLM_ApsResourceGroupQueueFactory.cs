//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsResourceGroupQueueFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsResourceGroupQueueFactory
	{
		public ICLM_ApsResourceGroupQueue Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsResourceGroupQueue = new Production.APS.CLM_ApsResourceGroupQueue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsResourceGroupQueueExt = timerfactory.Create<Production.APS.ICLM_ApsResourceGroupQueue>(_CLM_ApsResourceGroupQueue);
			
			return iCLM_ApsResourceGroupQueueExt;
		}
	}
}
