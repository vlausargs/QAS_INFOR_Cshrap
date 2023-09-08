//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetInvProfileFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class CLM_ApsGetInvProfileFactory
    {
        public ICLM_ApsGetInvProfile Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ApsGetInvProfile = new CLM_ApsGetInvProfile(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetInvProfileExt = timerfactory.Create<ICLM_ApsGetInvProfile>(_CLM_ApsGetInvProfile);

            return iCLM_ApsGetInvProfileExt;
        }
    }
}
