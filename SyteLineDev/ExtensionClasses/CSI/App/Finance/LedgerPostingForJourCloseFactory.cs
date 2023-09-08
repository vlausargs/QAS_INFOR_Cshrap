//PROJECT NAME: Finance
//CLASS NAME: LedgerPostingForJourCloseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class LedgerPostingForJourCloseFactory
	{
		public ILedgerPostingForJourClose Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LedgerPostingForJourClose = new Finance.LedgerPostingForJourClose(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLedgerPostingForJourCloseExt = timerfactory.Create<Finance.ILedgerPostingForJourClose>(_LedgerPostingForJourClose);
			
			return iLedgerPostingForJourCloseExt;
		}
	}
}
