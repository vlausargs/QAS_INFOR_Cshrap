//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_ShowLedgerFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_ShowLedgerFactory
    {
        public ICHSCLM_ShowLedger Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_ShowLedger = new CHSCLM_ShowLedger(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_ShowLedgerExt = timerfactory.Create<ICHSCLM_ShowLedger>(_CHSCLM_ShowLedger);

            return iCHSCLM_ShowLedgerExt;
        }
    }
}

