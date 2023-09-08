//PROJECT NAME: CSIVendor
//CLASS NAME: CreateWhtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class CreateWhtFactory
    {
        public ICreateWht Create(IApplicationDB appDB)
        {
            var _CreateWht = new Vendor.CreateWht(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCreateWhtExt = timerfactory.Create<Vendor.ICreateWht>(_CreateWht);

            return iCreateWhtExt;
        }
    }
}
