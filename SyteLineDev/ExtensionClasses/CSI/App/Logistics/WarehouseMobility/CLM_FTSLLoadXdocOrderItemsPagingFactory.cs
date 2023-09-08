//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadXdocOrderItemsPagingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadXdocOrderItemsPagingFactory
	{
		public ICLM_FTSLLoadXdocOrderItemsPaging Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadXdocOrderItemsPaging = new Logistics.WarehouseMobility.CLM_FTSLLoadXdocOrderItemsPaging(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadXdocOrderItemsPagingExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadXdocOrderItemsPaging>(_CLM_FTSLLoadXdocOrderItemsPaging);
			
			return iCLM_FTSLLoadXdocOrderItemsPagingExt;
		}
	}
}
