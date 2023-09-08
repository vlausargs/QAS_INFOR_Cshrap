//PROJECT NAME: CSICustomer
//CLASS NAME: Home_MetricInventoryShipRcvFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Home_MetricInventoryShipRcvFactory
    {
        public IHome_MetricInventoryShipRcv Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Home_MetricInventoryShipRcv = new Home_MetricInventoryShipRcv(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_MetricInventoryShipRcvExt = timerfactory.Create<IHome_MetricInventoryShipRcv>(_Home_MetricInventoryShipRcv);

            return iHome_MetricInventoryShipRcvExt;
        }
    }
}
