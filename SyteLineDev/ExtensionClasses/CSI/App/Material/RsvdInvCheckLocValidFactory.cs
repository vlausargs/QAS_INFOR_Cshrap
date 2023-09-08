//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvCheckLocValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RsvdInvCheckLocValidFactory
    {
        public IRsvdInvCheckLocValid Create(IApplicationDB appDB)
        {
            var _RsvdInvCheckLocValid = new RsvdInvCheckLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRsvdInvCheckLocValidExt = timerfactory.Create<IRsvdInvCheckLocValid>(_RsvdInvCheckLocValid);

            return iRsvdInvCheckLocValidExt;
        }
    }
}
