//PROJECT NAME: CSIVendor
//CLASS NAME: AllocFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AllocFactory
    {
        public IAlloc Create(IApplicationDB appDB)
        {
            var _Alloc = new Logistics.Vendor.Alloc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAllocExt = timerfactory.Create<Logistics.Vendor.IAlloc>(_Alloc);

            return iAllocExt;
        }
    }
}
