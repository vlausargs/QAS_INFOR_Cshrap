//PROJECT NAME: CSICustomer
//CLASS NAME: EDICustomerOrderValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EDICustomerOrderValidFactory
    {
        public IEDICustomerOrderValid Create(IApplicationDB appDB)
        {
            var _EDICustomerOrderValid = new Logistics.Customer.EDICustomerOrderValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEDICustomerOrderValidExt = timerfactory.Create<Logistics.Customer.IEDICustomerOrderValid>(_EDICustomerOrderValid);

            return iEDICustomerOrderValidExt;
        }
    }
}
