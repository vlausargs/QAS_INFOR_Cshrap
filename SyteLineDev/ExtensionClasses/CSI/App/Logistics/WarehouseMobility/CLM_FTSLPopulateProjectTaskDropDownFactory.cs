//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateProjectTaskDropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateProjectTaskDropDownFactory
	{
		public ICLM_FTSLPopulateProjectTaskDropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateProjectTaskDropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateProjectTaskDropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateProjectTaskDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateProjectTaskDropDown>(_CLM_FTSLPopulateProjectTaskDropDown);
			
			return iCLM_FTSLPopulateProjectTaskDropDownExt;
		}
	}
}
