//PROJECT NAME: CSIFinance
//CLASS NAME: BankCompFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class BankCompFactory
	{
		public IBankComp Create(IApplicationDB appDB)
		{
			var _BankComp = new Finance.BankComp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBankCompExt = timerfactory.Create<Finance.IBankComp>(_BankComp);
			
			return iBankCompExt;
		}
	}
}
