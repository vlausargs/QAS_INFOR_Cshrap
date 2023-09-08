//PROJECT NAME: Finance
//CLASS NAME: SSSCCIProcessCardWrapFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIProcessCardWrapFactory
	{
		public ISSSCCIProcessCardWrap Create(IApplicationDB appDB)
		{
			var _SSSCCIProcessCardWrap = new Finance.CreditCard.SSSCCIProcessCardWrap(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIProcessCardWrapExt = timerfactory.Create<Finance.CreditCard.ISSSCCIProcessCardWrap>(_SSSCCIProcessCardWrap);
			
			return iSSSCCIProcessCardWrapExt;
		}
	}
}
