//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECNbyItemFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ECNbyItemFactory
	{
		public IRpt_ECNbyItem Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ECNbyItem = new Reporting.Rpt_ECNbyItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ECNbyItemExt = timerfactory.Create<Reporting.IRpt_ECNbyItem>(_Rpt_ECNbyItem);
			
			return iRpt_ECNbyItemExt;
		}
	}
}
