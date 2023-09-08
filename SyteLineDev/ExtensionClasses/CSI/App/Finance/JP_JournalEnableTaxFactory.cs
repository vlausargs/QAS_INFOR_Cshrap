//PROJECT NAME: CSIFinance
//CLASS NAME: JP_JournalEnableTaxFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class JP_JournalEnableTaxFactory
	{
		public IJP_JournalEnableTax Create(IApplicationDB appDB)
		{
			var _JP_JournalEnableTax = new Finance.JP_JournalEnableTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJP_JournalEnableTaxExt = timerfactory.Create<Finance.IJP_JournalEnableTax>(_JP_JournalEnableTax);
			
			return iJP_JournalEnableTaxExt;
		}
	}
}
