//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLTaskLabelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLTaskLabelFactory
	{
		public ICLM_FTSLTaskLabel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLTaskLabel = new Logistics.WarehouseMobility.CLM_FTSLTaskLabel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLTaskLabelExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLTaskLabel>(_CLM_FTSLTaskLabel);
			
			return iCLM_FTSLTaskLabelExt;
		}
	}
}
