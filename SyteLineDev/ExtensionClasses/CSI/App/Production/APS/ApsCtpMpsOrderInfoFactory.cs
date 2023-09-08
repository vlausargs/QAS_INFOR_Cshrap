//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpMpsOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpMpsOrderInfoFactory
    {
        public IApsCtpMpsOrderInfo Create(IApplicationDB appDB)
        {
            var _ApsCtpMpsOrderInfo = new ApsCtpMpsOrderInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpMpsOrderInfoExt = timerfactory.Create<IApsCtpMpsOrderInfo>(_ApsCtpMpsOrderInfo);

            return iApsCtpMpsOrderInfoExt;
        }
    }
}
