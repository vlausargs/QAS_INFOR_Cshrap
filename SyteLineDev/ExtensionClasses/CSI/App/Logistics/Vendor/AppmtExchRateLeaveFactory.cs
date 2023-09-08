//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtExchRateLeaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtExchRateLeaveFactory
    {
        public IAppmtExchRateLeave Create(IApplicationDB appDB)
        {
            var _AppmtExchRateLeave = new Logistics.Vendor.AppmtExchRateLeave(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtExchRateLeaveExt = timerfactory.Create<Logistics.Vendor.IAppmtExchRateLeave>(_AppmtExchRateLeave);

            return iAppmtExchRateLeaveExt;
        }
    }
}

