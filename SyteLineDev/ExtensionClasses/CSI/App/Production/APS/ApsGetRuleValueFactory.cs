//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetRuleValueFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetRuleValueFactory
    {
        public IApsGetRuleValue Create(IApplicationDB appDB)
        {
            var _ApsGetRuleValue = new ApsGetRuleValue(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetRuleValueExt = timerfactory.Create<IApsGetRuleValue>(_ApsGetRuleValue);

            return iApsGetRuleValueExt;
        }
    }
}
