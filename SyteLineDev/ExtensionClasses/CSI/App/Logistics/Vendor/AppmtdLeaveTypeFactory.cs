//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtdLeaveTypeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtdLeaveTypeFactory
    {
        public IAppmtdLeaveType Create(IApplicationDB appDB)
        {
            var _AppmtdLeaveType = new Logistics.Vendor.AppmtdLeaveType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtdLeaveTypeExt = timerfactory.Create<Logistics.Vendor.IAppmtdLeaveType>(_AppmtdLeaveType);

            return iAppmtdLeaveTypeExt;
        }
    }
}