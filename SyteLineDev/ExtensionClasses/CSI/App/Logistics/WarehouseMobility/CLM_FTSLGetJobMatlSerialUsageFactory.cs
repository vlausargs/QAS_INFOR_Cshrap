//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetJobMatlSerialUsageFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetJobMatlSerialUsageFactory
	{
		public ICLM_FTSLGetJobMatlSerialUsage Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetJobMatlSerialUsage = new Logistics.WarehouseMobility.CLM_FTSLGetJobMatlSerialUsage(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetJobMatlSerialUsageExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetJobMatlSerialUsage>(_CLM_FTSLGetJobMatlSerialUsage);
			
			return iCLM_FTSLGetJobMatlSerialUsageExt;
		}
	}
}
