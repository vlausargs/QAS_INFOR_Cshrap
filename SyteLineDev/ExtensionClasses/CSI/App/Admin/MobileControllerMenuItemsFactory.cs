//PROJECT NAME: CSIAdmin
//CLASS NAME: MobileControllerMenuItemsFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class MobileControllerMenuItemsFactory
    {
        public IMobileControllerMenuItems Create(IApplicationDB appDB)
        {
            var _MobileControllerMenuItems = new MobileControllerMenuItems(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMobileControllerMenuItemsExt = timerfactory.Create<IMobileControllerMenuItems>(_MobileControllerMenuItems);

            return iMobileControllerMenuItemsExt;
        }
    }
}
