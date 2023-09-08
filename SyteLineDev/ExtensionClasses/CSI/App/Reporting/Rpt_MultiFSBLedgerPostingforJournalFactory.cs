//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBLedgerPostingforJournalFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBLedgerPostingforJournalFactory
	{
		public IRpt_MultiFSBLedgerPostingforJournal Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBLedgerPostingforJournal = new Reporting.Rpt_MultiFSBLedgerPostingforJournal(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBLedgerPostingforJournalExt = timerfactory.Create<Reporting.IRpt_MultiFSBLedgerPostingforJournal>(_Rpt_MultiFSBLedgerPostingforJournal);
			
			return iRpt_MultiFSBLedgerPostingforJournalExt;
		}
	}
}
