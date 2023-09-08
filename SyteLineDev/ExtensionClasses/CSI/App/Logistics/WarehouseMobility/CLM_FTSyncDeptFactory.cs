//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSyncDeptFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSyncDeptFactory
	{
		public ICLM_FTSyncDept Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSyncDept = new Logistics.WarehouseMobility.CLM_FTSyncDept(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSyncDeptExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSyncDept>(_CLM_FTSyncDept);
			
			return iCLM_FTSyncDeptExt;
		}
	}
}
