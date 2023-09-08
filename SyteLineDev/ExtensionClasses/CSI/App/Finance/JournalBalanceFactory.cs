//PROJECT NAME: Finance
//CLASS NAME: JournalBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalBalanceFactory
	{
		public IJournalBalance Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalBalance = new Finance.JournalBalance(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalBalanceExt = timerfactory.Create<Finance.IJournalBalance>(_JournalBalance);
			
			return iJournalBalanceExt;
		}
	}
}
