//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRemittanceFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranRemittanceFactory
	{
		public ILoadESBBankStmEntryDetailTranRemittance Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranRemittance = new BusInterface.LoadESBBankStmEntryDetailTranRemittance(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranRemittanceExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranRemittance>(_LoadESBBankStmEntryDetailTranRemittance);
			
			return iLoadESBBankStmEntryDetailTranRemittanceExt;
		}
	}
}
