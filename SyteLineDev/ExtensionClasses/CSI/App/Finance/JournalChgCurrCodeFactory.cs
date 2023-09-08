//PROJECT NAME: CSIFinance
//CLASS NAME: JournalChgCurrCodeFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class JournalChgCurrCodeFactory
	{
		public IJournalChgCurrCode Create(IApplicationDB appDB)
		{
			var _JournalChgCurrCode = new Finance.JournalChgCurrCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalChgCurrCodeExt = timerfactory.Create<Finance.IJournalChgCurrCode>(_JournalChgCurrCode);
			
			return iJournalChgCurrCodeExt;
		}
	}
}
