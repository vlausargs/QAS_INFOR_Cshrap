//PROJECT NAME: Admin
//CLASS NAME: PurgeJournalFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class PurgeJournalFactory
	{
		public IPurgeJournal Create(IApplicationDB appDB)
		{
			var _PurgeJournal = new Admin.PurgeJournal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeJournalExt = timerfactory.Create<Admin.IPurgeJournal>(_PurgeJournal);
			
			return iPurgeJournalExt;
		}
	}
}
