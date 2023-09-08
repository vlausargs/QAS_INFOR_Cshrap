//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSyncEmployeeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSyncEmployeeFactory
	{
		public ICLM_FTSyncEmployee Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSyncEmployee = new Logistics.WarehouseMobility.CLM_FTSyncEmployee(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSyncEmployeeExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSyncEmployee>(_CLM_FTSyncEmployee);
			
			return iCLM_FTSyncEmployeeExt;
		}
	}
}
