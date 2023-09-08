//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventorySummaryComparisonFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventorySummaryComparisonFactory
	{
		public IRpt_InventorySummaryComparison Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventorySummaryComparison = new Reporting.Rpt_InventorySummaryComparison(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventorySummaryComparisonExt = timerfactory.Create<Reporting.IRpt_InventorySummaryComparison>(_Rpt_InventorySummaryComparison);
			
			return iRpt_InventorySummaryComparisonExt;
		}
	}
}
