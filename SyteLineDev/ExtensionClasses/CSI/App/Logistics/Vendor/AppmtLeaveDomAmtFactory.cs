//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtLeaveDomAmtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtLeaveDomAmtFactory
    {
        public IAppmtLeaveDomAmt Create(IApplicationDB appDB)
        {
            var _AppmtLeaveDomAmt = new Logistics.Vendor.AppmtLeaveDomAmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtLeaveDomAmtExt = timerfactory.Create<Logistics.Vendor.IAppmtLeaveDomAmt>(_AppmtLeaveDomAmt);

            return iAppmtLeaveDomAmtExt;
        }
    }
}
