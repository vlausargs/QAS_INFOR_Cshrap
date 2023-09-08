//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvCheckRsvdQtyValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RsvdInvCheckRsvdQtyValidFactory
    {
        public IRsvdInvCheckRsvdQtyValid Create(IApplicationDB appDB)
        {
            var _RsvdInvCheckRsvdQtyValid = new RsvdInvCheckRsvdQtyValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRsvdInvCheckRsvdQtyValidExt = timerfactory.Create<IRsvdInvCheckRsvdQtyValid>(_RsvdInvCheckRsvdQtyValid);

            return iRsvdInvCheckRsvdQtyValidExt;
        }
    }
}
