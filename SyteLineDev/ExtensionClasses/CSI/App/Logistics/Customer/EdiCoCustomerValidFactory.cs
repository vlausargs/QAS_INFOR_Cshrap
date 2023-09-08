//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoCustomerValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCoCustomerValidFactory
    {
        public IEdiCoCustomerValid Create(IApplicationDB appDB)
        {
            var _EdiCoCustomerValid = new Logistics.Customer.EdiCoCustomerValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCoCustomerValidExt = timerfactory.Create<Logistics.Customer.IEdiCoCustomerValid>(_EdiCoCustomerValid);

            return iEdiCoCustomerValidExt;
        }
    }
}
