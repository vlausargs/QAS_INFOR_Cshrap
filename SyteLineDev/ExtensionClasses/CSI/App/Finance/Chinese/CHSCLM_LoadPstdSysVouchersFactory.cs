//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadPstdSysVouchersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSCLM_LoadPstdSysVouchersFactory
	{
		public ICHSCLM_LoadPstdSysVouchers Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSCLM_LoadPstdSysVouchers = new Finance.Chinese.CHSCLM_LoadPstdSysVouchers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCLM_LoadPstdSysVouchersExt = timerfactory.Create<Finance.Chinese.ICHSCLM_LoadPstdSysVouchers>(_CHSCLM_LoadPstdSysVouchers);
			
			return iCHSCLM_LoadPstdSysVouchersExt;
		}
	}
}
