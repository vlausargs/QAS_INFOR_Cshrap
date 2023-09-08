//PROJECT NAME: Finance
//CLASS NAME: TTJournalVerifyPrintFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalVerifyPrintFactory
	{
		public ITTJournalVerifyPrint Create(IApplicationDB appDB)
		{
			var _TTJournalVerifyPrint = new Finance.TTJournalVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalVerifyPrintExt = timerfactory.Create<Finance.ITTJournalVerifyPrint>(_TTJournalVerifyPrint);
			
			return iTTJournalVerifyPrintExt;
		}
	}
}
