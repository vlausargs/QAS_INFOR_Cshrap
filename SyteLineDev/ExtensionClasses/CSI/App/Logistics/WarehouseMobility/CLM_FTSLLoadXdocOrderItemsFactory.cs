//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadXdocOrderItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadXdocOrderItemsFactory
	{
		public ICLM_FTSLLoadXdocOrderItems Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadXdocOrderItems = new Logistics.WarehouseMobility.CLM_FTSLLoadXdocOrderItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadXdocOrderItemsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadXdocOrderItems>(_CLM_FTSLLoadXdocOrderItems);
			
			return iCLM_FTSLLoadXdocOrderItemsExt;
		}
	}
}
