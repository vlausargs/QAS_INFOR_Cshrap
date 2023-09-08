//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLJobStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLJobStatusFactory
	{
		public ICLM_FTSLJobStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLJobStatus = new Logistics.WarehouseMobility.CLM_FTSLJobStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLJobStatusExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLJobStatus>(_CLM_FTSLJobStatus);
			
			return iCLM_FTSLJobStatusExt;
		}
	}
}
