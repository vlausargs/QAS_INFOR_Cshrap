//PROJECT NAME: CSIAdmin
//CLASS NAME: MobileSPMenuItemsFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class MobileSPMenuItemsFactory
    {
        public IMobileSPMenuItems Create(IApplicationDB appDB)
        {
            var _MobileSPMenuItems = new MobileSPMenuItems(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMobileSPMenuItemsExt = timerfactory.Create<IMobileSPMenuItems>(_MobileSPMenuItems);

            return iMobileSPMenuItemsExt;
        }
    }
}
