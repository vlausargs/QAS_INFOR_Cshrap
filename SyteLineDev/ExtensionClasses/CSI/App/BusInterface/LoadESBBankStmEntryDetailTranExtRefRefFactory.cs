//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranExtRefRefFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranExtRefRefFactory
	{
		public ILoadESBBankStmEntryDetailTranExtRefRef Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranExtRefRef = new BusInterface.LoadESBBankStmEntryDetailTranExtRefRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranExtRefRefExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranExtRefRef>(_LoadESBBankStmEntryDetailTranExtRefRef);
			
			return iLoadESBBankStmEntryDetailTranExtRefRefExt;
		}
	}
}
