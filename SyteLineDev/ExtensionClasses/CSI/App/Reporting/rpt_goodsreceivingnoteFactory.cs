//PROJECT NAME: Reporting
//CLASS NAME: rpt_goodsreceivingnoteFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class rpt_goodsreceivingnoteFactory
	{
		public Irpt_goodsreceivingnote Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _rpt_goodsreceivingnote = new Reporting.rpt_goodsreceivingnote(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var irpt_goodsreceivingnoteExt = timerfactory.Create<Reporting.Irpt_goodsreceivingnote>(_rpt_goodsreceivingnote);
			
			return irpt_goodsreceivingnoteExt;
		}
	}
}
