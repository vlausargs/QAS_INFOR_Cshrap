//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLContainerLabelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLContainerLabelFactory
	{
		public ICLM_FTSLContainerLabel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLContainerLabel = new Logistics.WarehouseMobility.CLM_FTSLContainerLabel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLContainerLabelExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLContainerLabel>(_CLM_FTSLContainerLabel);
			
			return iCLM_FTSLContainerLabelExt;
		}
	}
}
