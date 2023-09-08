//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetResourceIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetResourceIdFactory
	{
		public ICLM_FTSLGetResourceId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetResourceId = new Logistics.WarehouseMobility.CLM_FTSLGetResourceId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetResourceIdExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetResourceId>(_CLM_FTSLGetResourceId);
			
			return iCLM_FTSLGetResourceIdExt;
		}
	}
}
