//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsMPSItemFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpIsMPSItemFactory
    {
        public IApsCtpIsMPSItem Create(IApplicationDB appDB)
        {
            var _ApsCtpIsMPSItem = new ApsCtpIsMPSItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpIsMPSItemExt = timerfactory.Create<IApsCtpIsMPSItem>(_ApsCtpIsMPSItem);

            return iApsCtpIsMPSItemExt;
        }
    }
}
