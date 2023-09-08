//PROJECT NAME: Material
//CLASS NAME: CLM_InventoryBelowSafetyStockFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_InventoryBelowSafetyStockFactory
	{
		public ICLM_InventoryBelowSafetyStock Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_InventoryBelowSafetyStock = new Material.CLM_InventoryBelowSafetyStock(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_InventoryBelowSafetyStockExt = timerfactory.Create<Material.ICLM_InventoryBelowSafetyStock>(_CLM_InventoryBelowSafetyStock);
			
			return iCLM_InventoryBelowSafetyStockExt;
		}
	}
}
