//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetWorkCenterServiceOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetWorkCenterServiceOrdersFactory
	{
		public ICLM_FTSLGetWorkCenterServiceOrders Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetWorkCenterServiceOrders = new Logistics.WarehouseMobility.CLM_FTSLGetWorkCenterServiceOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetWorkCenterServiceOrdersExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetWorkCenterServiceOrders>(_CLM_FTSLGetWorkCenterServiceOrders);
			
			return iCLM_FTSLGetWorkCenterServiceOrdersExt;
		}
	}
}
