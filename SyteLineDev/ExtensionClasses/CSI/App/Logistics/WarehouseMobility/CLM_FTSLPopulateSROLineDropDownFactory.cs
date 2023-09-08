//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateSROLineDropDownFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateSROLineDropDownFactory
	{
		public ICLM_FTSLPopulateSROLineDropDown Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateSROLineDropDown = new Logistics.WarehouseMobility.CLM_FTSLPopulateSROLineDropDown(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateSROLineDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateSROLineDropDown>(_CLM_FTSLPopulateSROLineDropDown);
			
			return iCLM_FTSLPopulateSROLineDropDownExt;
		}
	}
}
