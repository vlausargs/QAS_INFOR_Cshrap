//PROJECT NAME: Finance
//CLASS NAME: TTMassJournalVerifyPrintFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTMassJournalVerifyPrintFactory
	{
		public ITTMassJournalVerifyPrint Create(IApplicationDB appDB)
		{
			var _TTMassJournalVerifyPrint = new Finance.TTMassJournalVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTMassJournalVerifyPrintExt = timerfactory.Create<Finance.ITTMassJournalVerifyPrint>(_TTMassJournalVerifyPrint);
			
			return iTTMassJournalVerifyPrintExt;
		}
	}
}
