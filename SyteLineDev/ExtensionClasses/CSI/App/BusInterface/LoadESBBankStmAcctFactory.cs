//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctFactory
	{
		public ILoadESBBankStmAcct Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcct = new BusInterface.LoadESBBankStmAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcct>(_LoadESBBankStmAcct);
			
			return iLoadESBBankStmAcctExt;
		}
	}
}
