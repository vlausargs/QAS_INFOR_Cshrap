//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSyncTimeOffGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSyncTimeOffGroupFactory
	{
		public ICLM_FTSyncTimeOffGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSyncTimeOffGroup = new Logistics.WarehouseMobility.CLM_FTSyncTimeOffGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSyncTimeOffGroupExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSyncTimeOffGroup>(_CLM_FTSyncTimeOffGroup);
			
			return iCLM_FTSyncTimeOffGroupExt;
		}
	}
}
