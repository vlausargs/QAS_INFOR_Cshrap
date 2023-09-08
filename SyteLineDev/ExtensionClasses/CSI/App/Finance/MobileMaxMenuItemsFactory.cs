//PROJECT NAME: CSIFinance
//CLASS NAME: MobileMaxMenuItemsFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MobileMaxMenuItemsFactory
    {
        public IMobileMaxMenuItems Create(IApplicationDB appDB)
        {
            var _MobileMaxMenuItems = new MobileMaxMenuItems(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLExecutivesExt = timerfactory.Create<IMobileMaxMenuItems>(_MobileMaxMenuItems);

            return iSLExecutivesExt;
        }
    }
}
