//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemCostingFactory
	{
		public IRpt_ItemCosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemCosting = new Reporting.Rpt_ItemCosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemCostingExt = timerfactory.Create<Reporting.IRpt_ItemCosting>(_Rpt_ItemCosting);
			
			return iRpt_ItemCostingExt;
		}
	}
}
