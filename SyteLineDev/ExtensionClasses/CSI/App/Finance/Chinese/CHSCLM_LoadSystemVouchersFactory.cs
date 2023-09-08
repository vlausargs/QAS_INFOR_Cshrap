//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadSystemVouchersFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_LoadSystemVouchersFactory
    {
        public ICHSCLM_LoadSystemVouchers Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_LoadSystemVouchers = new CHSCLM_LoadSystemVouchers(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_LoadSystemVouchersExt = timerfactory.Create<ICHSCLM_LoadSystemVouchers>(_CHSCLM_LoadSystemVouchers);

            return iCHSCLM_LoadSystemVouchersExt;
        }
    }
}
