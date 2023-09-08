//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLKanbanPickListDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLKanbanPickListDetailFactory
	{
		public ICLM_FTSLKanbanPickListDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLKanbanPickListDetail = new Logistics.WarehouseMobility.CLM_FTSLKanbanPickListDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLKanbanPickListDetailExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLKanbanPickListDetail>(_CLM_FTSLKanbanPickListDetail);
			
			return iCLM_FTSLKanbanPickListDetailExt;
		}
	}
}
