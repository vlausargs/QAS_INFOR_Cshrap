//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSyncHolidayFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSyncHolidayFactory
	{
		public ICLM_FTSyncHoliday Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSyncHoliday = new Logistics.WarehouseMobility.CLM_FTSyncHoliday(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSyncHolidayExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSyncHoliday>(_CLM_FTSyncHoliday);
			
			return iCLM_FTSyncHolidayExt;
		}
	}
}
