//PROJECT NAME: CSIMaterial
//CLASS NAME: MrpSyncMpwFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MrpSyncMpwFactory
    {
        public IMrpSyncMpw Create(IApplicationDB appDB)
        {
            var _MrpSyncMpw = new MrpSyncMpw(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMrpSyncMpwExt = timerfactory.Create<IMrpSyncMpw>(_MrpSyncMpw);

            return iMrpSyncMpwExt;
        }
    }
}
