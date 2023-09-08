//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpJobOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpJobOrderInfoFactory
    {
        public IApsCtpJobOrderInfo Create(IApplicationDB appDB)
        {
            var _ApsCtpJobOrderInfo = new ApsCtpJobOrderInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpJobOrderInfoExt = timerfactory.Create<IApsCtpJobOrderInfo>(_ApsCtpJobOrderInfo);

            return iApsCtpJobOrderInfoExt;
        }
    }
}
