//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSyncShiftFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSyncShiftFactory
	{
		public ICLM_FTSyncShift Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSyncShift = new Logistics.WarehouseMobility.CLM_FTSyncShift(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSyncShiftExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSyncShift>(_CLM_FTSyncShift);
			
			return iCLM_FTSyncShiftExt;
		}
	}
}
