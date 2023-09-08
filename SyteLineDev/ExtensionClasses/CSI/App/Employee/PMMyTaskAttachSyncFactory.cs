//PROJECT NAME: CSIEmployee
//CLASS NAME: PMMyTaskAttachSyncFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PMMyTaskAttachSyncFactory
    {
        public IPMMyTaskAttachSync Create(IApplicationDB appDB)
        {
            var _PMMyTaskAttachSync = new PMMyTaskAttachSync(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPMMyTaskAttachSyncExt = timerfactory.Create<IPMMyTaskAttachSync>(_PMMyTaskAttachSync);

            return iPMMyTaskAttachSyncExt;
        }
    }
}
