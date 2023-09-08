//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECNStatusFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ECNStatusFactory
	{
		public IRpt_ECNStatus Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ECNStatus = new Reporting.Rpt_ECNStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ECNStatusExt = timerfactory.Create<Reporting.IRpt_ECNStatus>(_Rpt_ECNStatus);
			
			return iRpt_ECNStatusExt;
		}
	}
}
