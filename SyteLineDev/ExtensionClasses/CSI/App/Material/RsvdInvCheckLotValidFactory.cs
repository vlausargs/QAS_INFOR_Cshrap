//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvCheckLotValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RsvdInvCheckLotValidFactory
    {
        public IRsvdInvCheckLotValid Create(IApplicationDB appDB)
        {
            var _RsvdInvCheckLotValid = new RsvdInvCheckLotValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRsvdInvCheckLotValidExt = timerfactory.Create<IRsvdInvCheckLotValid>(_RsvdInvCheckLotValid);

            return iRsvdInvCheckLotValidExt;
        }
    }
}
