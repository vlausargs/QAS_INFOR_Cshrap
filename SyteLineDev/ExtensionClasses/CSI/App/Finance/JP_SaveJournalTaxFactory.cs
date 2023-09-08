//PROJECT NAME: Finance
//CLASS NAME: JP_SaveJournalTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JP_SaveJournalTaxFactory
	{
		public IJP_SaveJournalTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JP_SaveJournalTax = new Finance.JP_SaveJournalTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJP_SaveJournalTaxExt = timerfactory.Create<Finance.IJP_SaveJournalTax>(_JP_SaveJournalTax);
			
			return iJP_SaveJournalTaxExt;
		}
	}
}
