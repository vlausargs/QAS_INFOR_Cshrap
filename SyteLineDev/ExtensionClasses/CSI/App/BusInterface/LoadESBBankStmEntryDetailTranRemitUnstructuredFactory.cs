//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRemitUnstructuredFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranRemitUnstructuredFactory
	{
		public ILoadESBBankStmEntryDetailTranRemitUnstructured Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranRemitUnstructured = new BusInterface.LoadESBBankStmEntryDetailTranRemitUnstructured(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranRemitUnstructuredExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranRemitUnstructured>(_LoadESBBankStmEntryDetailTranRemitUnstructured);
			
			return iLoadESBBankStmEntryDetailTranRemitUnstructuredExt;
		}
	}
}
