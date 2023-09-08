//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtPostNeededFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtPostNeededFactory
    {
        public IAppmtPostNeeded Create(IApplicationDB appDB)
        {
            var _AppmtPostNeeded = new Logistics.Vendor.AppmtPostNeeded(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtPostNeededExt = timerfactory.Create<Logistics.Vendor.IAppmtPostNeeded>(_AppmtPostNeeded);

            return iAppmtPostNeededExt;
        }
    }
}
