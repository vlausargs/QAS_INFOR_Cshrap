//PROJECT NAME: Finance
//CLASS NAME: TTJournalUpdaFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalUpdaFactory
	{
		public ITTJournalUpda Create(IApplicationDB appDB)
		{
			var _TTJournalUpda = new Finance.TTJournalUpda(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalUpdaExt = timerfactory.Create<Finance.ITTJournalUpda>(_TTJournalUpda);
			
			return iTTJournalUpdaExt;
		}
	}
}
