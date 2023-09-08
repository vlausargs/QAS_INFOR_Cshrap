//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLEmployeeLabelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLEmployeeLabelFactory
	{
		public ICLM_FTSLEmployeeLabel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLEmployeeLabel = new Logistics.WarehouseMobility.CLM_FTSLEmployeeLabel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLEmployeeLabelExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLEmployeeLabel>(_CLM_FTSLEmployeeLabel);
			
			return iCLM_FTSLEmployeeLabelExt;
		}
	}
}
