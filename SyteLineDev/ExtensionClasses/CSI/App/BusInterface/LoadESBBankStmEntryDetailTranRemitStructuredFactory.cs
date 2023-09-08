//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRemitStructuredFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranRemitStructuredFactory
	{
		public ILoadESBBankStmEntryDetailTranRemitStructured Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranRemitStructured = new BusInterface.LoadESBBankStmEntryDetailTranRemitStructured(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranRemitStructuredExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranRemitStructured>(_LoadESBBankStmEntryDetailTranRemitStructured);
			
			return iLoadESBBankStmEntryDetailTranRemitStructuredExt;
		}
	}
}
