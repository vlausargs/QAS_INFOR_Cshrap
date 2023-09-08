//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLValidateProjTaskFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLValidateProjTaskFactory
	{
		public ICLM_FTSLValidateProjTask Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLValidateProjTask = new Logistics.WarehouseMobility.CLM_FTSLValidateProjTask(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLValidateProjTaskExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLValidateProjTask>(_CLM_FTSLValidateProjTask);
			
			return iCLM_FTSLValidateProjTaskExt;
		}
	}
}
