//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetWCActiveTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetWCActiveTransFactory
	{
		public ICLM_FTSLGetWCActiveTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetWCActiveTrans = new Logistics.WarehouseMobility.CLM_FTSLGetWCActiveTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetWCActiveTransExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetWCActiveTrans>(_CLM_FTSLGetWCActiveTrans);
			
			return iCLM_FTSLGetWCActiveTransExt;
		}
	}
}
