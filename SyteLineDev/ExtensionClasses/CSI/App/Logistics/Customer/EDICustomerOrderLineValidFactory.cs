//PROJECT NAME: CSICustomer
//CLASS NAME: EDICustomerOrderLineValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EDICustomerOrderLineValidFactory
    {
        public IEDICustomerOrderLineValid Create(IApplicationDB appDB)
        {
            var _EDICustomerOrderLineValid = new Logistics.Customer.EDICustomerOrderLineValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEDICustomerOrderLineValidExt = timerfactory.Create<Logistics.Customer.IEDICustomerOrderLineValid>(_EDICustomerOrderLineValid);

            return iEDICustomerOrderLineValidExt;
        }
    }
}
