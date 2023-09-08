//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCurrentRoutingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemCurrentRoutingFactory
	{
		public IRpt_ItemCurrentRouting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemCurrentRouting = new Reporting.Rpt_ItemCurrentRouting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemCurrentRoutingExt = timerfactory.Create<Reporting.IRpt_ItemCurrentRouting>(_Rpt_ItemCurrentRouting);
			
			return iRpt_ItemCurrentRoutingExt;
		}
	}
}
