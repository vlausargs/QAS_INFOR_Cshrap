//PROJECT NAME: CSICustomer
//CLASS NAME: CustomerDueDateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CustomerDueDateFactory
    {
        public ICustomerDueDate Create(IApplicationDB appDB)
        {
            var _CustomerDueDate = new Logistics.Customer.CustomerDueDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCustomerDueDateExt = timerfactory.Create<Logistics.Customer.ICustomerDueDate>(_CustomerDueDate);

            return iCustomerDueDateExt;
        }
    }
}
