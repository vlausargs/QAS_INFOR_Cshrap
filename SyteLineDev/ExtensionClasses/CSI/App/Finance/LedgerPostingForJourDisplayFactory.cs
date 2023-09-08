//PROJECT NAME: CSIFinance
//CLASS NAME: LedgerPostingForJourDisplayFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class LedgerPostingForJourDisplayFactory
	{
		public ILedgerPostingForJourDisplay Create(IApplicationDB appDB)
		{
			var _LedgerPostingForJourDisplay = new Finance.LedgerPostingForJourDisplay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLedgerPostingForJourDisplayExt = timerfactory.Create<Finance.ILedgerPostingForJourDisplay>(_LedgerPostingForJourDisplay);
			
			return iLedgerPostingForJourDisplayExt;
		}
	}
}
