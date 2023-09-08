//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtPreDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtPreDeleteFactory
    {
        public IAppmtPreDelete Create(IApplicationDB appDB)
        {
            var _AppmtPreDelete = new Logistics.Vendor.AppmtPreDelete(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtPreDeleteExt = timerfactory.Create<Logistics.Vendor.IAppmtPreDelete>(_AppmtPreDelete);

            return iAppmtPreDeleteExt;
        }
    }
}
