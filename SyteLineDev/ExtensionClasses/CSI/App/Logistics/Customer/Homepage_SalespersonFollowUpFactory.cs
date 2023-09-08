//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_SalespersonFollowUpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_SalespersonFollowUpFactory
    {
        public IHomepage_SalespersonFollowUp Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_SalespersonFollowUp = new Logistics.Customer.Homepage_SalespersonFollowUp(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_SalespersonFollowUpExt = timerfactory.Create<Logistics.Customer.IHomepage_SalespersonFollowUp>(_Homepage_SalespersonFollowUp);

            return iHomepage_SalespersonFollowUpExt;
        }
    }
}
