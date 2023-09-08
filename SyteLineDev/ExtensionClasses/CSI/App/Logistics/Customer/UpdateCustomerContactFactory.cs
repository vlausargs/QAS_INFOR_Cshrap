//PROJECT NAME: CSICustomer
//CLASS NAME: UpdateCustomerContactFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class UpdateCustomerContactFactory
    {
        public IUpdateCustomerContact Create(IApplicationDB appDB)
        {
            var _UpdateCustomerContact = new Customer.UpdateCustomerContact(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUpdateCustomerContactExt = timerfactory.Create<Customer.IUpdateCustomerContact>(_UpdateCustomerContact);

            return iUpdateCustomerContactExt;
        }
    }
}
