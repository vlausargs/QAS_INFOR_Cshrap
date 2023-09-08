//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryBelowSafetyStockFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventoryBelowSafetyStockFactory
	{
		public IRpt_InventoryBelowSafetyStock Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventoryBelowSafetyStock = new Reporting.Rpt_InventoryBelowSafetyStock(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryBelowSafetyStockExt = timerfactory.Create<Reporting.IRpt_InventoryBelowSafetyStock>(_Rpt_InventoryBelowSafetyStock);
			
			return iRpt_InventoryBelowSafetyStockExt;
		}
	}
}
