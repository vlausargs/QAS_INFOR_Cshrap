//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetSchedValuesFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetSchedValuesFactory
    {
        public IApsGetSchedValues Create(IApplicationDB appDB)
        {
            var _ApsGetSchedValues = new ApsGetSchedValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetSchedValuesExt = timerfactory.Create<IApsGetSchedValues>(_ApsGetSchedValues);

            return iApsGetSchedValuesExt;
        }
    }
}
