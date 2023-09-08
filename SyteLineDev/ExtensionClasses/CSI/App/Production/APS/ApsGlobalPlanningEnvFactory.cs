//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGlobalPlanningEnvFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGlobalPlanningEnvFactory
    {
        public IApsGlobalPlanningEnv Create(IApplicationDB appDB)
        {
            var _ApsGlobalPlanningEnv = new ApsGlobalPlanningEnv(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGlobalPlanningEnvExt = timerfactory.Create<IApsGlobalPlanningEnv>(_ApsGlobalPlanningEnv);

            return iApsGlobalPlanningEnvExt;
        }
    }
}
