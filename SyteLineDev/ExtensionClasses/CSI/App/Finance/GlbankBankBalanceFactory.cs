//PROJECT NAME: CSIFinance
//CLASS NAME: GlbankBankBalanceFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GlbankBankBalanceFactory
	{
		public IGlbankBankBalance Create(IApplicationDB appDB)
		{
			var _GlbankBankBalance = new Finance.GlbankBankBalance(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlbankBankBalanceExt = timerfactory.Create<Finance.IGlbankBankBalance>(_GlbankBankBalance);
			
			return iGlbankBankBalanceExt;
		}
	}
}
