//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctEntryFactory
	{
		public ILoadESBBankStmAcctEntry Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcctEntry = new BusInterface.LoadESBBankStmAcctEntry(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctEntryExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcctEntry>(_LoadESBBankStmAcctEntry);
			
			return iLoadESBBankStmAcctEntryExt;
		}
	}
}
