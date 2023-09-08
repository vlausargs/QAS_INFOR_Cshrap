//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_VoucherTrxnSummaryByFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_VoucherTrxnSummaryByFactory
    {
        public ICHSCLM_VoucherTrxnSummaryBy Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_VoucherTrxnSummaryBy = new CHSCLM_VoucherTrxnSummaryBy(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_VoucherTrxnSummaryByExt = timerfactory.Create<ICHSCLM_VoucherTrxnSummaryBy>(_CHSCLM_VoucherTrxnSummaryBy);

            return iCHSCLM_VoucherTrxnSummaryByExt;
        }
    }
}
