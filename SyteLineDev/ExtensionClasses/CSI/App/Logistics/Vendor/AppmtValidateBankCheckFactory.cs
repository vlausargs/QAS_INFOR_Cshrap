//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtValidateBankCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtValidateBankCheckFactory
    {
        public IAppmtValidateBankCheck Create(IApplicationDB appDB)
        {
            var _AppmtValidateBankCheck = new Logistics.Vendor.AppmtValidateBankCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtValidateBankCheckExt = timerfactory.Create<Logistics.Vendor.IAppmtValidateBankCheck>(_AppmtValidateBankCheck);

            return iAppmtValidateBankCheckExt;
        }
    }
}
