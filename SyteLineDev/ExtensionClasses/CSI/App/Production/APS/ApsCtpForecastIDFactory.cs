//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpForecastIDFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpForecastIDFactory
    {
        public IApsCtpForecastID Create(IApplicationDB appDB)
        {
            var _ApsCtpForecastID = new ApsCtpForecastID(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpForecastIDExt = timerfactory.Create<IApsCtpForecastID>(_ApsCtpForecastID);

            return iApsCtpForecastIDExt;
        }
    }
}
