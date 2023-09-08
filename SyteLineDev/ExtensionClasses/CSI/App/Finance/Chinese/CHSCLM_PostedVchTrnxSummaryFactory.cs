//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_PostedVchTrnxSummaryFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_PostedVchTrnxSummaryFactory
    {
        public ICHSCLM_PostedVchTrnxSummary Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_PostedVchTrnxSummary = new CHSCLM_PostedVchTrnxSummary(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_PostedVchTrnxSummaryExt = timerfactory.Create<ICHSCLM_PostedVchTrnxSummary>(_CHSCLM_PostedVchTrnxSummary);

            return iCHSCLM_PostedVchTrnxSummaryExt;
        }
    }
}
