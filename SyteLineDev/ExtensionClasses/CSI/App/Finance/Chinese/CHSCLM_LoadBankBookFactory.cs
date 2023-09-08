//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadBankBookFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSCLM_LoadBankBookFactory
    {
        public ICHSCLM_LoadBankBook Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSCLM_LoadBankBook = new CHSCLM_LoadBankBook(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSCLM_LoadBankBookExt = timerfactory.Create<ICHSCLM_LoadBankBook>(_CHSCLM_LoadBankBook);

            return iCHSCLM_LoadBankBookExt;
        }
    }
}
