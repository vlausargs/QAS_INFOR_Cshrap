//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtGetCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtGetCheckFactory
    {
        public IAppmtGetCheck Create(IApplicationDB appDB)
        {
            var _AppmtGetCheck = new Logistics.Vendor.AppmtGetCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtGetCheckExt = timerfactory.Create<Logistics.Vendor.IAppmtGetCheck>(_AppmtGetCheck);

            return iAppmtGetCheckExt;
        }
    }
}
