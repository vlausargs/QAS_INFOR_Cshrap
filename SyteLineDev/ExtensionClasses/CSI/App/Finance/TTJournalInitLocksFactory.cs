//PROJECT NAME: Finance
//CLASS NAME: TTJournalInitLocksFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalInitLocksFactory
	{
		public ITTJournalInitLocks Create(IApplicationDB appDB)
		{
			var _TTJournalInitLocks = new Finance.TTJournalInitLocks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalInitLocksExt = timerfactory.Create<Finance.ITTJournalInitLocks>(_TTJournalInitLocks);
			
			return iTTJournalInitLocksExt;
		}
	}
}
