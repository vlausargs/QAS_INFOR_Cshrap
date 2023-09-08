//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerbyAccountFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerbyAccountFactory
	{
		public IRpt_GeneralLedgerbyAccount Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GeneralLedgerbyAccount = new Reporting.Rpt_GeneralLedgerbyAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GeneralLedgerbyAccountExt = timerfactory.Create<Reporting.IRpt_GeneralLedgerbyAccount>(_Rpt_GeneralLedgerbyAccount);
			
			return iRpt_GeneralLedgerbyAccountExt;
		}
	}
}
