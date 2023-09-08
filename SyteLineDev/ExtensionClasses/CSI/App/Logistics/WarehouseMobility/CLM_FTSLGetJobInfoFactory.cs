//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetJobInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetJobInfoFactory
	{
		public ICLM_FTSLGetJobInfo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetJobInfo = new Logistics.WarehouseMobility.CLM_FTSLGetJobInfo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetJobInfoExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetJobInfo>(_CLM_FTSLGetJobInfo);
			
			return iCLM_FTSLGetJobInfoExt;
		}
	}
}
