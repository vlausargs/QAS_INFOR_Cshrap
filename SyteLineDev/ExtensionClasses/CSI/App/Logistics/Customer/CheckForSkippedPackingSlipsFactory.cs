//PROJECT NAME: CSICustomer
//CLASS NAME: CheckForSkippedPackingSlipsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CheckForSkippedPackingSlipsFactory
    {
        public ICheckForSkippedPackingSlips Create(IApplicationDB appDB)
        {
            var _CheckForSkippedPackingSlips = new Customer.CheckForSkippedPackingSlips(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckForSkippedPackingSlipsExt = timerfactory.Create<Customer.ICheckForSkippedPackingSlips>(_CheckForSkippedPackingSlips);

            return iCheckForSkippedPackingSlipsExt;
        }
    }
}
