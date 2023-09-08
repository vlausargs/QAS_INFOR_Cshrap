//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadPostedVouchersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSCLM_LoadPostedVouchersFactory
	{
		public ICHSCLM_LoadPostedVouchers Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSCLM_LoadPostedVouchers = new Finance.Chinese.CHSCLM_LoadPostedVouchers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCLM_LoadPostedVouchersExt = timerfactory.Create<Finance.Chinese.ICHSCLM_LoadPostedVouchers>(_CHSCLM_LoadPostedVouchers);
			
			return iCHSCLM_LoadPostedVouchersExt;
		}
	}
}
