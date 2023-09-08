//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetItemsNonInventoryItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetItemsNonInventoryItemsFactory
	{
		public ICLM_FTSLGetItemsNonInventoryItems Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetItemsNonInventoryItems = new Logistics.WarehouseMobility.CLM_FTSLGetItemsNonInventoryItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetItemsNonInventoryItemsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetItemsNonInventoryItems>(_CLM_FTSLGetItemsNonInventoryItems);
			
			return iCLM_FTSLGetItemsNonInventoryItemsExt;
		}
	}
}
