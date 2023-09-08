//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetPlannerResrcUtilFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class CLM_ApsGetPlannerResrcUtilFactory
    {
        public ICLM_ApsGetPlannerResrcUtil Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ApsGetPlannerResrcUtil = new CLM_ApsGetPlannerResrcUtil(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetPlannerResrcUtilExt = timerfactory.Create<ICLM_ApsGetPlannerResrcUtil>(_CLM_ApsGetPlannerResrcUtil);

            return iCLM_ApsGetPlannerResrcUtilExt;
        }
    }
}
