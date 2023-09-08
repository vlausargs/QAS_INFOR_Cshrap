//PROJECT NAME: Finance
//CLASS NAME: TTJournalDeleteFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalDeleteFactory
	{
		public ITTJournalDelete Create(IApplicationDB appDB)
		{
			var _TTJournalDelete = new Finance.TTJournalDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalDeleteExt = timerfactory.Create<Finance.ITTJournalDelete>(_TTJournalDelete);
			
			return iTTJournalDeleteExt;
		}
	}
}
