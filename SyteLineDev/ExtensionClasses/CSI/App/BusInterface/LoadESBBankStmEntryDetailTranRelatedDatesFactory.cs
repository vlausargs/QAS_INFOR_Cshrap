//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRelatedDatesFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmEntryDetailTranRelatedDatesFactory
	{
		public ILoadESBBankStmEntryDetailTranRelatedDates Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmEntryDetailTranRelatedDates = new BusInterface.LoadESBBankStmEntryDetailTranRelatedDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmEntryDetailTranRelatedDatesExt = timerfactory.Create<BusInterface.ILoadESBBankStmEntryDetailTranRelatedDates>(_LoadESBBankStmEntryDetailTranRelatedDates);
			
			return iLoadESBBankStmEntryDetailTranRelatedDatesExt;
		}
	}
}
