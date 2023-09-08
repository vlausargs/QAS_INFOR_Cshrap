//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetKanbanLabelPrintingDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetKanbanLabelPrintingDataFactory
	{
		public ICLM_FTSLGetKanbanLabelPrintingData Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetKanbanLabelPrintingData = new Logistics.WarehouseMobility.CLM_FTSLGetKanbanLabelPrintingData(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetKanbanLabelPrintingDataExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetKanbanLabelPrintingData>(_CLM_FTSLGetKanbanLabelPrintingData);
			
			return iCLM_FTSLGetKanbanLabelPrintingDataExt;
		}
	}
}
