//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateOperationDropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateOperationDropDownFactory
	{
		public ICLM_FTSLPopulateOperationDropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateOperationDropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateOperationDropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateOperationDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateOperationDropDown>(_CLM_FTSLPopulateOperationDropDown);
			
			return iCLM_FTSLPopulateOperationDropDownExt;
		}
	}
}
