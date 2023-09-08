//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadJobtranitemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadJobtranitemFactory
	{
		public ICLM_FTSLLoadJobtranitem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadJobtranitem = new Logistics.WarehouseMobility.CLM_FTSLLoadJobtranitem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadJobtranitemExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadJobtranitem>(_CLM_FTSLLoadJobtranitem);
			
			return iCLM_FTSLLoadJobtranitemExt;
		}
	}
}
