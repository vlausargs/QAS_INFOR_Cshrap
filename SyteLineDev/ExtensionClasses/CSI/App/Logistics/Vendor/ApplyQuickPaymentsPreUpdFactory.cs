//PROJECT NAME: CSIVendor
//CLASS NAME: ApplyQuickPaymentsPreUpdFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class ApplyQuickPaymentsPreUpdFactory
    {
        public IApplyQuickPaymentsPreUpd Create(IApplicationDB appDB)
        {
            var _ApplyQuickPaymentsPreUpd = new Logistics.Vendor.ApplyQuickPaymentsPreUpd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApplyQuickPaymentsPreUpdExt = timerfactory.Create<Logistics.Vendor.IApplyQuickPaymentsPreUpd>(_ApplyQuickPaymentsPreUpd);

            return iApplyQuickPaymentsPreUpdExt;
        }
    }
}
