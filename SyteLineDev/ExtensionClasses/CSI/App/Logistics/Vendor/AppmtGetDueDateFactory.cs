//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtGetDueDateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtGetDueDateFactory
    {
        public IAppmtGetDueDate Create(IApplicationDB appDB)
        {
            var _AppmtGetDueDate = new Logistics.Vendor.AppmtGetDueDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtGetDueDateExt = timerfactory.Create<Logistics.Vendor.IAppmtGetDueDate>(_AppmtGetDueDate);

            return iAppmtGetDueDateExt;
        }
    }
}
