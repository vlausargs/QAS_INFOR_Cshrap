//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetAltPlanGraphFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class CLM_ApsGetAltPlanGraphFactory
    {
        public ICLM_ApsGetAltPlanGraph Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ApsGetAltPlanGraph = new CLM_ApsGetAltPlanGraph(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetAltPlanGraphExt = timerfactory.Create<ICLM_ApsGetAltPlanGraph>(_CLM_ApsGetAltPlanGraph);

            return iCLM_ApsGetAltPlanGraphExt;
        }
    }
}
