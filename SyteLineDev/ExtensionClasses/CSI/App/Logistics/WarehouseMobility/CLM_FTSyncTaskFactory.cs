//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSyncTaskFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSyncTaskFactory
	{
		public ICLM_FTSyncTask Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSyncTask = new Logistics.WarehouseMobility.CLM_FTSyncTask(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSyncTaskExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSyncTask>(_CLM_FTSyncTask);
			
			return iCLM_FTSyncTaskExt;
		}
	}
}
