//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctInvolvedAmountsFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctInvolvedAmountsFactory
	{
		public ILoadESBBankStmAcctInvolvedAmounts Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcctInvolvedAmounts = new BusInterface.LoadESBBankStmAcctInvolvedAmounts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctInvolvedAmountsExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcctInvolvedAmounts>(_LoadESBBankStmAcctInvolvedAmounts);
			
			return iLoadESBBankStmAcctInvolvedAmountsExt;
		}
	}
}
