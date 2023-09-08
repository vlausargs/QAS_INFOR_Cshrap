//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpForecastOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpForecastOrderInfoFactory
    {
        public IApsCtpForecastOrderInfo Create(IApplicationDB appDB)
        {
            var _ApsCtpForecastOrderInfo = new ApsCtpForecastOrderInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpForecastOrderInfoExt = timerfactory.Create<IApsCtpForecastOrderInfo>(_ApsCtpForecastOrderInfo);

            return iApsCtpForecastOrderInfoExt;
        }
    }
}
