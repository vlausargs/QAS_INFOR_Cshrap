//PROJECT NAME: Finance
//CLASS NAME: TTJournalGetTextFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalGetTextFactory
	{
		public ITTJournalGetText Create(IApplicationDB appDB)
		{
			var _TTJournalGetText = new Finance.TTJournalGetText(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalGetTextExt = timerfactory.Create<Finance.ITTJournalGetText>(_TTJournalGetText);
			
			return iTTJournalGetTextExt;
		}
	}
}
