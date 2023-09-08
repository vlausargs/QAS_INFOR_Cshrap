//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLocationLabelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLocationLabelFactory
	{
		public ICLM_FTSLLocationLabel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLocationLabel = new Logistics.WarehouseMobility.CLM_FTSLLocationLabel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLocationLabelExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLocationLabel>(_CLM_FTSLLocationLabel);
			
			return iCLM_FTSLLocationLabelExt;
		}
	}
}
