//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateJobDropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateJobDropDownFactory
	{
		public ICLM_FTSLPopulateJobDropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateJobDropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateJobDropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateJobDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateJobDropDown>(_CLM_FTSLPopulateJobDropDown);
			
			return iCLM_FTSLPopulateJobDropDownExt;
		}
	}
}
