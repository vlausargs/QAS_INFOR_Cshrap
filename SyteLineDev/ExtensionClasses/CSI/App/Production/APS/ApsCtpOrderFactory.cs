//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpOrderFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpOrderFactory
    {
        public IApsCtpOrder Create(IApplicationDB appDB)
        {
            var _ApsCtpOrder = new ApsCtpOrder(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpOrderExt = timerfactory.Create<IApsCtpOrder>(_ApsCtpOrder);

            return iApsCtpOrderExt;
        }
    }
}
