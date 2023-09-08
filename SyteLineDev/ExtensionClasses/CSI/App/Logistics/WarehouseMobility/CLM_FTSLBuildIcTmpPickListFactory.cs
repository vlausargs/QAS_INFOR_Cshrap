//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLBuildIcTmpPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLBuildIcTmpPickListFactory
	{
		public ICLM_FTSLBuildIcTmpPickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLBuildIcTmpPickList = new Logistics.WarehouseMobility.CLM_FTSLBuildIcTmpPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLBuildIcTmpPickListExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLBuildIcTmpPickList>(_CLM_FTSLBuildIcTmpPickList);
			
			return iCLM_FTSLBuildIcTmpPickListExt;
		}
	}
}
