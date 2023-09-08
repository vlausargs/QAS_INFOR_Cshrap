//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingCleanupFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class POReceivingCleanupFactory
    {
        public IPOReceivingCleanup Create(IApplicationDB appDB)
        {
            var _POReceivingCleanup = new Logistics.Vendor.POReceivingCleanup(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPOReceivingCleanupExt = timerfactory.Create<Logistics.Vendor.IPOReceivingCleanup>(_POReceivingCleanup);

            return iPOReceivingCleanupExt;
        }
    }
}
