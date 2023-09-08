//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_ListBankReconFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_ListBankReconFactory
    {
        public ICHSCLM_ListBankRecon Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_ListBankRecon = new CHSCLM_ListBankRecon(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_ListBankReconExt = timerfactory.Create<ICHSCLM_ListBankRecon>(_CHSCLM_ListBankRecon);

            return iCHSCLM_ListBankReconExt;
        }
    }
}