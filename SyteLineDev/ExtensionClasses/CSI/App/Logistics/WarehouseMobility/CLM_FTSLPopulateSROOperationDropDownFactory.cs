//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateSROOperationDropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateSROOperationDropDownFactory
	{
		public ICLM_FTSLPopulateSROOperationDropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateSROOperationDropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateSROOperationDropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateSROOperationDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateSROOperationDropDown>(_CLM_FTSLPopulateSROOperationDropDown);
			
			return iCLM_FTSLPopulateSROOperationDropDownExt;
		}
	}
}
