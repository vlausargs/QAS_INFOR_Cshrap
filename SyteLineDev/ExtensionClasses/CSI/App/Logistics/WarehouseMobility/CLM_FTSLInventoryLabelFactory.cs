//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLInventoryLabelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLInventoryLabelFactory
	{
		public ICLM_FTSLInventoryLabel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLInventoryLabel = new Logistics.WarehouseMobility.CLM_FTSLInventoryLabel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLInventoryLabelExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLInventoryLabel>(_CLM_FTSLInventoryLabel);
			
			return iCLM_FTSLInventoryLabelExt;
		}
	}
}
