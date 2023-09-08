//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetEmpInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetEmpInfoFactory
	{
		public ICLM_FTSLGetEmpInfo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetEmpInfo = new Logistics.WarehouseMobility.CLM_FTSLGetEmpInfo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetEmpInfoExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetEmpInfo>(_CLM_FTSLGetEmpInfo);
			
			return iCLM_FTSLGetEmpInfoExt;
		}
	}
}
