//PROJECT NAME: CSIVendor
//CLASS NAME: APQuickPayInitialFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class APQuickPayInitialFactory
    {
        public IAPQuickPayInitial Create(IApplicationDB appDB)
        {
            var _APQuickPayInitial = new Logistics.Vendor.APQuickPayInitial(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPQuickPayInitialExt = timerfactory.Create<Logistics.Vendor.IAPQuickPayInitial>(_APQuickPayInitial);

            return iAPQuickPayInitialExt;
        }
    }
}