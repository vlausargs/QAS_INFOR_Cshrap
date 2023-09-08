//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranExtRefFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranExtRefFactory
	{
		public ILoadESBBankStmEntryDetailTranExtRef Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranExtRef = new BusInterface.LoadESBBankStmEntryDetailTranExtRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranExtRefExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranExtRef>(_LoadESBBankStmEntryDetailTranExtRef);
			
			return iLoadESBBankStmEntryDetailTranExtRefExt;
		}
	}
}
