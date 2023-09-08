//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateSRODropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateSRODropDownFactory
	{
		public ICLM_FTSLPopulateSRODropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateSRODropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateSRODropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateSRODropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateSRODropDown>(_CLM_FTSLPopulateSRODropDown);
			
			return iCLM_FTSLPopulateSRODropDownExt;
		}
	}
}
