//PROJECT NAME: CSIFinance
//CLASS NAME: DeleteTmpMassJournalFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class DeleteTmpMassJournalFactory
	{
		public IDeleteTmpMassJournal Create(IApplicationDB appDB)
		{
			var _DeleteTmpMassJournal = new Finance.DeleteTmpMassJournal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTmpMassJournalExt = timerfactory.Create<Finance.IDeleteTmpMassJournal>(_DeleteTmpMassJournal);
			
			return iDeleteTmpMassJournalExt;
		}
	}
}
