//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryDetailTranReturnFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctEntryDetailTranReturnFactory
	{
		public ILoadESBBankStmAcctEntryDetailTranReturn Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcctEntryDetailTranReturn = new BusInterface.LoadESBBankStmAcctEntryDetailTranReturn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctEntryDetailTranReturnExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcctEntryDetailTranReturn>(_LoadESBBankStmAcctEntryDetailTranReturn);
			
			return iLoadESBBankStmAcctEntryDetailTranReturnExt;
		}
	}
}
