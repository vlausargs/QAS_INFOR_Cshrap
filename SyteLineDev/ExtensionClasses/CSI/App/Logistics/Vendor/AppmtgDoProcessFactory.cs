//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtgDoProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtgDoProcessFactory
    {
        public IAppmtgDoProcess Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _AppmtgDoProcess = new Logistics.Vendor.AppmtgDoProcess(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtgDoProcessExt = timerfactory.Create<Logistics.Vendor.IAppmtgDoProcess>(_AppmtgDoProcess);

            return iAppmtgDoProcessExt;
        }
    }
}
