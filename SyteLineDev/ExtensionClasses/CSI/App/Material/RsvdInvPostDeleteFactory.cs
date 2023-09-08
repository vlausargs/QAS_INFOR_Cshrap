//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvPostDeleteFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RsvdInvPostDeleteFactory
    {
        public IRsvdInvPostDelete Create(IApplicationDB appDB)
        {
            var _RsvdInvPostDelete = new RsvdInvPostDelete(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRsvdInvPostDeleteExt = timerfactory.Create<IRsvdInvPostDelete>(_RsvdInvPostDelete);

            return iRsvdInvPostDeleteExt;
        }
    }
}
