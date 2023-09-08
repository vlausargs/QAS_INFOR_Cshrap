//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryDetailTranFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctEntryDetailTranFactory
	{
		public ILoadESBBankStmAcctEntryDetailTran Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcctEntryDetailTran = new BusInterface.LoadESBBankStmAcctEntryDetailTran(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctEntryDetailTranExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcctEntryDetailTran>(_LoadESBBankStmAcctEntryDetailTran);
			
			return iLoadESBBankStmAcctEntryDetailTranExt;
		}
	}
}
