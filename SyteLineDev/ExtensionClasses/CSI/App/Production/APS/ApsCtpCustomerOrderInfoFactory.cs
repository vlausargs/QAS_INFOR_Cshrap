//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpCustomerOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpCustomerOrderInfoFactory
    {
        public IApsCtpCustomerOrderInfo Create(IApplicationDB appDB)
        {
            var _ApsCtpCustomerOrderInfo = new ApsCtpCustomerOrderInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpCustomerOrderInfoExt = timerfactory.Create<IApsCtpCustomerOrderInfo>(_ApsCtpCustomerOrderInfo);

            return iApsCtpCustomerOrderInfoExt;
        }
    }
}
