//PROJECT NAME: Finance
//CLASS NAME: SSSCCICheckOrderAuthorizedFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCICheckOrderAuthorizedFactory
	{
		public ISSSCCICheckOrderAuthorized Create(IApplicationDB appDB)
		{
			var _SSSCCICheckOrderAuthorized = new Finance.CreditCard.SSSCCICheckOrderAuthorized(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCICheckOrderAuthorizedExt = timerfactory.Create<Finance.CreditCard.ISSSCCICheckOrderAuthorized>(_SSSCCICheckOrderAuthorized);
			
			return iSSSCCICheckOrderAuthorizedExt;
		}
	}
}
