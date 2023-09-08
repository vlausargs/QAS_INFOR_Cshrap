//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyInteractionsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_MyInteractionsFactory
    {
        public IHomepage_MyInteractions Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_MyInteractions = new Logistics.Customer.Homepage_MyInteractions(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_MyInteractionsExt = timerfactory.Create<Logistics.Customer.IHomepage_MyInteractions>(_Homepage_MyInteractions);

            return iHomepage_MyInteractionsExt;
        }
    }
}
