//PROJECT NAME: Finance
//CLASS NAME: JournalCalcForAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalCalcForAmtFactory
	{
		public IJournalCalcForAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalCalcForAmt = new Finance.JournalCalcForAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalCalcForAmtExt = timerfactory.Create<Finance.IJournalCalcForAmt>(_JournalCalcForAmt);
			
			return iJournalCalcForAmtExt;
		}
	}
}
