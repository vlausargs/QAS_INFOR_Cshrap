//PROJECT NAME: Finance
//CLASS NAME: TTMassJournalVerifyPrintNotesFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTMassJournalVerifyPrintNotesFactory
	{
		public ITTMassJournalVerifyPrintNotes Create(IApplicationDB appDB)
		{
			var _TTMassJournalVerifyPrintNotes = new Finance.TTMassJournalVerifyPrintNotes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTMassJournalVerifyPrintNotesExt = timerfactory.Create<Finance.ITTMassJournalVerifyPrintNotes>(_TTMassJournalVerifyPrintNotes);
			
			return iTTMassJournalVerifyPrintNotesExt;
		}
	}
}
