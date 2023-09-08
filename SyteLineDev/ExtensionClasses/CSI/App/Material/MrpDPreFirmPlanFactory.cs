//PROJECT NAME: CSIMaterial
//CLASS NAME: MrpDPreFirmPlanFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MrpDPreFirmPlanFactory
    {
        public IMrpDPreFirmPlan Create(IApplicationDB appDB)
        {
            var _MrpDPreFirmPlan = new MrpDPreFirmPlan(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMrpDPreFirmPlanExt = timerfactory.Create<IMrpDPreFirmPlan>(_MrpDPreFirmPlan);

            return iMrpDPreFirmPlanExt;
        }
    }
}
