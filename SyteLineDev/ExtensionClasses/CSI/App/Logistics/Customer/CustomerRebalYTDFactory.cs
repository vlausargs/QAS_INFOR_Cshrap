//PROJECT NAME: CSICustomer
//CLASS NAME: CustomerRebalYTDFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CustomerRebalYTDFactory
    {
        public ICustomerRebalYTD Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CustomerRebalYTD = new Logistics.Customer.CustomerRebalYTD(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCustomerRebalYTDExt = timerfactory.Create<Logistics.Customer.ICustomerRebalYTD>(_CustomerRebalYTD);

            return iCustomerRebalYTDExt;
        }
    }
}
