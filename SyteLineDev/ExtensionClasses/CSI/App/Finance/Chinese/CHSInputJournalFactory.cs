//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSInputJournalFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSInputJournalFactory
	{
		public ICHSInputJournal Create(IApplicationDB appDB)
		{
			var _CHSInputJournal = new Finance.Chinese.CHSInputJournal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSInputJournalExt = timerfactory.Create<Finance.Chinese.ICHSInputJournal>(_CHSInputJournal);
			
			return iCHSInputJournalExt;
		}
	}
}
