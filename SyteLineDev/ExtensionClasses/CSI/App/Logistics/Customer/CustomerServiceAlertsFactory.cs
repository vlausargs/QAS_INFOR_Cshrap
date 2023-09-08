//PROJECT NAME: CSICustomer
//CLASS NAME: CustomerServiceAlertsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CustomerServiceAlertsFactory
    {
        public ICustomerServiceAlerts Create(IApplicationDB appDB)
        {
            var _CustomerServiceAlerts = new CustomerServiceAlerts(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCustomerServiceAlertsExt = timerfactory.Create<ICustomerServiceAlerts>(_CustomerServiceAlerts);

            return iCustomerServiceAlertsExt;
        }
    }
}
