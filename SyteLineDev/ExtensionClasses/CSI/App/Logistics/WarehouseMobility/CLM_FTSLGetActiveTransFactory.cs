//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetActiveTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetActiveTransFactory
	{
		public ICLM_FTSLGetActiveTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetActiveTrans = new Logistics.WarehouseMobility.CLM_FTSLGetActiveTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetActiveTransExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetActiveTrans>(_CLM_FTSLGetActiveTrans);
			
			return iCLM_FTSLGetActiveTransExt;
		}
	}
}
