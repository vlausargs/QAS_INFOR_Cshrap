//PROJECT NAME: Finance
//CLASS NAME: TTJournalVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalVerifyCloseFormFactory
	{
		public ITTJournalVerifyCloseForm Create(IApplicationDB appDB)
		{
			var _TTJournalVerifyCloseForm = new Finance.TTJournalVerifyCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalVerifyCloseFormExt = timerfactory.Create<Finance.ITTJournalVerifyCloseForm>(_TTJournalVerifyCloseForm);
			
			return iTTJournalVerifyCloseFormExt;
		}
	}
}
