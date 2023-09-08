//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadLedgerEntriesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSCLM_LoadLedgerEntriesFactory
	{
		public ICHSCLM_LoadLedgerEntries Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSCLM_LoadLedgerEntries = new Finance.Chinese.CHSCLM_LoadLedgerEntries(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCLM_LoadLedgerEntriesExt = timerfactory.Create<Finance.Chinese.ICHSCLM_LoadLedgerEntries>(_CHSCLM_LoadLedgerEntries);
			
			return iCHSCLM_LoadLedgerEntriesExt;
		}
	}
}
