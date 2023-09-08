//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBChartofAccountsFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBChartofAccountsFactory
	{
		public ILoadESBChartofAccounts Create(IApplicationDB appDB)
		{
			var _LoadESBChartofAccounts = new BusInterface.LoadESBChartofAccounts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBChartofAccountsExt = timerfactory.Create<BusInterface.ILoadESBChartofAccounts>(_LoadESBChartofAccounts);
			
			return iLoadESBChartofAccountsExt;
		}
	}
}
