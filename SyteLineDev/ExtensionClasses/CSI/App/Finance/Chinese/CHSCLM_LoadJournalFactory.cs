//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadJournalFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSCLM_LoadJournalFactory
	{
		public ICHSCLM_LoadJournal Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSCLM_LoadJournal = new Finance.Chinese.CHSCLM_LoadJournal(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCLM_LoadJournalExt = timerfactory.Create<Finance.Chinese.ICHSCLM_LoadJournal>(_CHSCLM_LoadJournal);
			
			return iCHSCLM_LoadJournalExt;
		}
	}
}
