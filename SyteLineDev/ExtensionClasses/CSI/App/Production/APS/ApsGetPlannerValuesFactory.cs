//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetPlannerValuesFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetPlannerValuesFactory
    {
        public IApsGetPlannerValues Create(IApplicationDB appDB)
        {
            var _ApsGetPlannerValues = new ApsGetPlannerValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetPlannerValuesExt = timerfactory.Create<IApsGetPlannerValues>(_ApsGetPlannerValues);

            return iApsGetPlannerValuesExt;
        }
    }
}
