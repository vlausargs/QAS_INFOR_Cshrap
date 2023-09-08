//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRelatedPartiesFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranRelatedPartiesFactory
	{
		public ILoadESBBankStmEntryDetailTranRelatedParties Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranRelatedParties = new BusInterface.LoadESBBankStmEntryDetailTranRelatedParties(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranRelatedPartiesExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranRelatedParties>(_LoadESBBankStmEntryDetailTranRelatedParties);
			
			return iLoadESBBankStmEntryDetailTranRelatedPartiesExt;
		}
	}
}
