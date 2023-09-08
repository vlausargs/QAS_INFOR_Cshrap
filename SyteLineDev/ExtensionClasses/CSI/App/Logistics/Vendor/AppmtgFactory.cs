//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtgFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtgFactory
    {
        public IAppmtg Create(IApplicationDB appDB)
        {
            var _Appmtg = new Logistics.Vendor.Appmtg(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtgExt = timerfactory.Create<Logistics.Vendor.IAppmtg>(_Appmtg);

            return iAppmtgExt;
        }
    }
}