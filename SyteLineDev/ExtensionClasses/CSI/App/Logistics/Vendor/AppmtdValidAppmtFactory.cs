//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtdValidAppmtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtdValidAppmtFactory
    {
        public IAppmtdValidAppmt Create(IApplicationDB appDB)
        {
            var _AppmtdValidAppmt = new Logistics.Vendor.AppmtdValidAppmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtdValidAppmtExt = timerfactory.Create<Logistics.Vendor.IAppmtdValidAppmt>(_AppmtdValidAppmt);

            return iAppmtdValidAppmtExt;
        }
    }
}