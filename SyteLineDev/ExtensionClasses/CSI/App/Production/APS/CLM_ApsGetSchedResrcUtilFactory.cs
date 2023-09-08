//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetSchedResrcUtilFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class CLM_ApsGetSchedResrcUtilFactory
    {
        public ICLM_ApsGetSchedResrcUtil Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ApsGetSchedResrcUtil = new CLM_ApsGetSchedResrcUtil(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetSchedResrcUtilExt = timerfactory.Create<ICLM_ApsGetSchedResrcUtil>(_CLM_ApsGetSchedResrcUtil);

            return iCLM_ApsGetSchedResrcUtilExt;
        }
    }
}
