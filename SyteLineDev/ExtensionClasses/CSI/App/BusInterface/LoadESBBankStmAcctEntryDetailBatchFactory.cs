//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryDetailBatchFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmAcctEntryDetailBatchFactory
	{
		public ILoadESBBankStmAcctEntryDetailBatch Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmAcctEntryDetailBatch = new BusInterface.LoadESBBankStmAcctEntryDetailBatch(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmAcctEntryDetailBatchExt = timerfactory.Create<BusInterface.ILoadESBBankStmAcctEntryDetailBatch>(_LoadESBBankStmAcctEntryDetailBatch);
			
			return iLoadESBBankStmAcctEntryDetailBatchExt;
		}
	}
}
