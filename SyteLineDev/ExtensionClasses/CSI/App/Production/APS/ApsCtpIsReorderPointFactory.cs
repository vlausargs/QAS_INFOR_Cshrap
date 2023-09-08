//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsReorderPointFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpIsReorderPointFactory
    {
        public IApsCtpIsReorderPoint Create(IApplicationDB appDB)
        {
            var _ApsCtpIsReorderPoint = new ApsCtpIsReorderPoint(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpIsReorderPointExt = timerfactory.Create<IApsCtpIsReorderPoint>(_ApsCtpIsReorderPoint);

            return iApsCtpIsReorderPointExt;
        }
    }
}
