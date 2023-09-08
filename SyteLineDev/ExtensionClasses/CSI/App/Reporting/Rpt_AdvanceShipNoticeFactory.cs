//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AdvanceShipNoticeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_AdvanceShipNoticeFactory
	{
		public IRpt_AdvanceShipNotice Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_AdvanceShipNotice = new Reporting.Rpt_AdvanceShipNotice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AdvanceShipNoticeExt = timerfactory.Create<Reporting.IRpt_AdvanceShipNotice>(_Rpt_AdvanceShipNotice);
			
			return iRpt_AdvanceShipNoticeExt;
		}
	}
}
