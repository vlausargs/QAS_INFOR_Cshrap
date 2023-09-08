//PROJECT NAME: CSIVendor
//CLASS NAME: ApPmtvFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class ApPmtvFactory
    {
        public IApPmtv Create(IApplicationDB appDB)
        {
            var _ApPmtv = new Logistics.Vendor.ApPmtv(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApPmtvExt = timerfactory.Create<Logistics.Vendor.IApPmtv>(_ApPmtv);

            return iApPmtvExt;
        }
    }
}
