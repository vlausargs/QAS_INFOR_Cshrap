//PROJECT NAME: CSICustomer
//CLASS NAME: Home_MetricCashImpactFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Home_MetricCashImpactFactory
    {
        public IHome_MetricCashImpact Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Home_MetricCashImpact = new Customer.Home_MetricCashImpact(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_MetricCashImpactExt = timerfactory.Create<Customer.IHome_MetricCashImpact>(_Home_MetricCashImpact);

            return iHome_MetricCashImpactExt;
        }
    }
}
