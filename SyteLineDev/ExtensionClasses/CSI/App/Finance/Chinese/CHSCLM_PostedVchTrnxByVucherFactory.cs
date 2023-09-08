//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_PostedVchTrnxByVucherFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_PostedVchTrnxByVucherFactory
    {
        public ICHSCLM_PostedVchTrnxByVucher Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_PostedVchTrnxByVucher = new CHSCLM_PostedVchTrnxByVucher(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_PostedVchTrnxByVucherExt = timerfactory.Create<ICHSCLM_PostedVchTrnxByVucher>(_CHSCLM_PostedVchTrnxByVucher);

            return iCHSCLM_PostedVchTrnxByVucherExt;
        }
    }
}
