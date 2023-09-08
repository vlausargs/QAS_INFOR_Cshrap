//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtSetForDomAmtsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtSetForDomAmtsFactory
    {
        public IAppmtSetForDomAmts Create(IApplicationDB appDB)
        {
            var _AppmtSetForDomAmts = new Logistics.Vendor.AppmtSetForDomAmts(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtSetForDomAmtsExt = timerfactory.Create<Logistics.Vendor.IAppmtSetForDomAmts>(_AppmtSetForDomAmts);

            return iAppmtSetForDomAmtsExt;
        }
    }
}