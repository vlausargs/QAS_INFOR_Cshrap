//PROJECT NAME: CSIMaterial
//CLASS NAME: InventoryControlAlertsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class InventoryControlAlertsFactory
    {
        public IInventoryControlAlerts Create(IApplicationDB appDB)
        {
            var _InventoryControlAlerts = new InventoryControlAlerts(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInventoryControlAlertsExt = timerfactory.Create<IInventoryControlAlerts>(_InventoryControlAlerts);

            return iInventoryControlAlertsExt;
        }
    }
}
