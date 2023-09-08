//PROJECT NAME: Finance
//CLASS NAME: JournalCalcDomAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalCalcDomAmtFactory
	{
		public IJournalCalcDomAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalCalcDomAmt = new Finance.JournalCalcDomAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalCalcDomAmtExt = timerfactory.Create<Finance.IJournalCalcDomAmt>(_JournalCalcDomAmt);
			
			return iJournalCalcDomAmtExt;
		}
	}
}
