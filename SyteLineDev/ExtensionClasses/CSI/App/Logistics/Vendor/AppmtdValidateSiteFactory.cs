//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtdValidateSiteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtdValidateSiteFactory
    {
        public IAppmtdValidateSite Create(IApplicationDB appDB)
        {
            var _AppmtdValidateSite = new Logistics.Vendor.AppmtdValidateSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtdValidateSiteExt = timerfactory.Create<Logistics.Vendor.IAppmtdValidateSite>(_AppmtdValidateSite);

            return iAppmtdValidateSiteExt;
        }
    }
}
