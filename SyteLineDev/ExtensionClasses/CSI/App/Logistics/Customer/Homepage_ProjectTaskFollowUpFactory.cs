//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ProjectTaskFollowUpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_ProjectTaskFollowUpFactory
    {
        public IHomepage_ProjectTaskFollowUp Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Homepage_ProjectTaskFollowUp = new Logistics.Customer.Homepage_ProjectTaskFollowUp(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_ProjectTaskFollowUpExt = timerfactory.Create<Logistics.Customer.IHomepage_ProjectTaskFollowUp>(_Homepage_ProjectTaskFollowUp);

            return iHomepage_ProjectTaskFollowUpExt;
        }
    }
}
