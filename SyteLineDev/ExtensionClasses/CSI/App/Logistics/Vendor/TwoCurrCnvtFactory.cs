//PROJECT NAME: Logistics
//CLASS NAME: TwoCurrCnvtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class TwoCurrCnvtFactory
    {
        public ITwoCurrCnvt Create(IApplicationDB appDB)
        {
            var _TwoCurrCnvt = new Logistics.Vendor.TwoCurrCnvt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTwoCurrCnvtExt = timerfactory.Create<Logistics.Vendor.ITwoCurrCnvt>(_TwoCurrCnvt);

            return iTwoCurrCnvtExt;
        }

        public ITwoCurrCnvt Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _2CurrCnvt = new Logistics.Vendor.TwoCurrCnvt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var i2CurrCnvtExt = timerfactory.Create<Logistics.Vendor.ITwoCurrCnvt>(_2CurrCnvt);

            return i2CurrCnvtExt;
        }
    }
}
