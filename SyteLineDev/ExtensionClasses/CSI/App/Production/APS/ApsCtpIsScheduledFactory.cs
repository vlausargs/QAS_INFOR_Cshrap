//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsScheduledFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpIsScheduledFactory
    {
        public IApsCtpIsScheduled Create(IApplicationDB appDB)
        {
            var _ApsCtpIsScheduled = new ApsCtpIsScheduled(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpIsScheduledExt = timerfactory.Create<IApsCtpIsScheduled>(_ApsCtpIsScheduled);

            return iApsCtpIsScheduledExt;
        }
    }
}
