//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CumulativeProductionbyItemFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CumulativeProductionbyItemFactory
	{
		public IRpt_CumulativeProductionbyItem Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CumulativeProductionbyItem = new Reporting.Rpt_CumulativeProductionbyItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CumulativeProductionbyItemExt = timerfactory.Create<Reporting.IRpt_CumulativeProductionbyItem>(_Rpt_CumulativeProductionbyItem);
			
			return iRpt_CumulativeProductionbyItemExt;
		}
	}
}
