//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_AccountBalanceBPFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_AccountBalanceBPFactory
    {
        public IHomepage_AccountBalanceBP Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_AccountBalanceBP = new Logistics.Customer.Homepage_AccountBalanceBP(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_AccountBalanceBPExt = timerfactory.Create<Logistics.Customer.IHomepage_AccountBalanceBP>(_Homepage_AccountBalanceBP);

            return iHomepage_AccountBalanceBPExt;
        }
    }
}
