//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateProjectDropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateProjectDropDownFactory
	{
		public ICLM_FTSLPopulateProjectDropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateProjectDropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateProjectDropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateProjectDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateProjectDropDown>(_CLM_FTSLPopulateProjectDropDown);
			
			return iCLM_FTSLPopulateProjectDropDownExt;
		}
	}
}
