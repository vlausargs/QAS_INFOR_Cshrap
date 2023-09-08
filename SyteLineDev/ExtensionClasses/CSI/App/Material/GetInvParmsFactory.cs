//PROJECT NAME: CSIMaterial
//CLASS NAME: GetInvParmsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetInvParmsFactory
    {
        public IGetInvParms Create(IApplicationDB appDB)
        {
            var _GetInvParms = new GetInvParms(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetInvParmsExt = timerfactory.Create<IGetInvParms>(_GetInvParms);

            return iGetInvParmsExt;
        }
    }
}
