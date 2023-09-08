//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLVisualDispatchFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLVisualDispatchFactory
	{
		public ICLM_FTSLVisualDispatch Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLVisualDispatch = new Logistics.WarehouseMobility.CLM_FTSLVisualDispatch(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLVisualDispatchExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLVisualDispatch>(_CLM_FTSLVisualDispatch);
			
			return iCLM_FTSLVisualDispatchExt;
		}
	}
}
