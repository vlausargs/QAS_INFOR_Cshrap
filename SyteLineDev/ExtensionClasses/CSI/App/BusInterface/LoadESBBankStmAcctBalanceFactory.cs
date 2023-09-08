//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctBalanceFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctBalanceFactory
	{
		public ILoadESBBankStmAcctBalance Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcctBalance = new BusInterface.LoadESBBankStmAcctBalance(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctBalanceExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcctBalance>(_LoadESBBankStmAcctBalance);
			
			return iLoadESBBankStmAcctBalanceExt;
		}
	}
}
