//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpProjectOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpProjectOrderInfoFactory
    {
        public IApsCtpProjectOrderInfo Create(IApplicationDB appDB)
        {
            var _ApsCtpProjectOrderInfo = new ApsCtpProjectOrderInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpProjectOrderInfoExt = timerfactory.Create<IApsCtpProjectOrderInfo>(_ApsCtpProjectOrderInfo);

            return iApsCtpProjectOrderInfoExt;
        }
    }
}
