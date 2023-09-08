//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpDisableExpediteFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpDisableExpediteFactory
    {
        public IApsCtpDisableExpedite Create(IApplicationDB appDB)
        {
            var _ApsCtpDisableExpedite = new ApsCtpDisableExpedite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpDisableExpediteExt = timerfactory.Create<IApsCtpDisableExpedite>(_ApsCtpDisableExpedite);

            return iApsCtpDisableExpediteExt;
        }
    }
}
