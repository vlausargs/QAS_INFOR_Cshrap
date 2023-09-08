//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetIssuedLotsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetIssuedLotsFactory
	{
		public ICLM_FTSLGetIssuedLots Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetIssuedLots = new Logistics.WarehouseMobility.CLM_FTSLGetIssuedLots(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetIssuedLotsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetIssuedLots>(_CLM_FTSLGetIssuedLots);
			
			return iCLM_FTSLGetIssuedLotsExt;
		}
	}
}
