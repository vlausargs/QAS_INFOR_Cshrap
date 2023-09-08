//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ResourceGroupOEEFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_ResourceGroupOEEFactory
    {
        public IHomepage_ResourceGroupOEE Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_ResourceGroupOEE = new Logistics.Customer.Homepage_ResourceGroupOEE(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_ResourceGroupOEEExt = timerfactory.Create<Logistics.Customer.IHomepage_ResourceGroupOEE>(_Homepage_ResourceGroupOEE);

            return iHomepage_ResourceGroupOEEExt;
        }
    }
}
