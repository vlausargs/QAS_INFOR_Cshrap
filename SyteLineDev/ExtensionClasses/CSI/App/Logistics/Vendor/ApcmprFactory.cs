//PROJECT NAME: CSIVendor
//CLASS NAME: ApcmprFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class ApcmprFactory
    {
        public IApcmpr Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Apcmpr = new Logistics.Vendor.Apcmpr(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApcmprExt = timerfactory.Create<Logistics.Vendor.IApcmpr>(_Apcmpr);

            return iApcmprExt;
        }
    }
}
