//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LedgerPostingforJournalFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LedgerPostingforJournalFactory
	{
		public IRpt_LedgerPostingforJournal Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LedgerPostingforJournal = new Reporting.Rpt_LedgerPostingforJournal(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LedgerPostingforJournalExt = timerfactory.Create<Reporting.IRpt_LedgerPostingforJournal>(_Rpt_LedgerPostingforJournal);
			
			return iRpt_LedgerPostingforJournalExt;
		}
	}
}
