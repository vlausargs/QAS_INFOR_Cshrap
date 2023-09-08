//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_PurchaseOrderFollowUpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_PurchaseOrderFollowUpFactory
    {
        public IHomepage_PurchaseOrderFollowUp Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_PurchaseOrderFollowUp = new Logistics.Customer.Homepage_PurchaseOrderFollowUp(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_PurchaseOrderFollowUpExt = timerfactory.Create<Logistics.Customer.IHomepage_PurchaseOrderFollowUp>(_Homepage_PurchaseOrderFollowUp);

            return iHomepage_PurchaseOrderFollowUpExt;
        }
    }
}
