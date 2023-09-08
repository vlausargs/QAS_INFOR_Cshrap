//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_ReturnedChecksFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class CLM_ReturnedChecksFactory
    {
        public ICLM_ReturnedChecks Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ReturnedChecks = new CLM_ReturnedChecks(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLGlbanksExt = timerfactory.Create<ICLM_ReturnedChecks>(_CLM_ReturnedChecks);

            return iSLGlbanksExt;
        }
    }
}
