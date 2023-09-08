//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ProductionFollowUpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_ProductionFollowUpFactory
    {
        public IHomepage_ProductionFollowUp Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_ProductionFollowUp = new Logistics.Customer.Homepage_ProductionFollowUp(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_ProductionFollowUpExt = timerfactory.Create<Logistics.Customer.IHomepage_ProductionFollowUp>(_Homepage_ProductionFollowUp);

            return iHomepage_ProductionFollowUpExt;
        }
    }
}
