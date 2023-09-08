//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadVouchersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSCLM_LoadVouchersFactory
	{
		public ICHSCLM_LoadVouchers Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSCLM_LoadVouchers = new Finance.Chinese.CHSCLM_LoadVouchers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCLM_LoadVouchersExt = timerfactory.Create<Finance.Chinese.ICHSCLM_LoadVouchers>(_CHSCLM_LoadVouchers);
			
			return iCHSCLM_LoadVouchersExt;
		}
	}
}
