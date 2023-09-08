//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryPreAdjustmentFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventoryPreAdjustmentFactory
	{
		public IRpt_InventoryPreAdjustment Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventoryPreAdjustment = new Reporting.Rpt_InventoryPreAdjustment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryPreAdjustmentExt = timerfactory.Create<Reporting.IRpt_InventoryPreAdjustment>(_Rpt_InventoryPreAdjustment);
			
			return iRpt_InventoryPreAdjustmentExt;
		}
	}
}
