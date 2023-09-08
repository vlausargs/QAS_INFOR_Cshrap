//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MySalespersonInteractionsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_MySalespersonInteractionsFactory
    {
        public IHomepage_MySalespersonInteractions Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_MySalespersonInteractions = new Logistics.Customer.Homepage_MySalespersonInteractions(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_MySalespersonInteractionsExt = timerfactory.Create<Logistics.Customer.IHomepage_MySalespersonInteractions>(_Homepage_MySalespersonInteractions);

            return iHomepage_MySalespersonInteractionsExt;
        }
    }
}
