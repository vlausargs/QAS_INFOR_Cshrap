//PROJECT NAME: Reporting
//CLASS NAME: Rpt_StatementofAccountFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting.Germany
{
	public class Rpt_StatementofAccountFactory
	{
		public IRpt_StatementofAccount Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_StatementofAccount = new Reporting.Germany.Rpt_StatementofAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_StatementofAccountExt = timerfactory.Create<Reporting.Germany.IRpt_StatementofAccount>(_Rpt_StatementofAccount);
			
			return iRpt_StatementofAccountExt;
		}
	}
}
