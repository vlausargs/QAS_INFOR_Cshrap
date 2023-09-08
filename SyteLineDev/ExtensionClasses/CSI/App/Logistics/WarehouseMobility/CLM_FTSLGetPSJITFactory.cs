//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetPSJITFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetPSJITFactory
	{
		public ICLM_FTSLGetPSJIT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetPSJIT = new Logistics.WarehouseMobility.CLM_FTSLGetPSJIT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetPSJITExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetPSJIT>(_CLM_FTSLGetPSJIT);
			
			return iCLM_FTSLGetPSJITExt;
		}
	}
}
