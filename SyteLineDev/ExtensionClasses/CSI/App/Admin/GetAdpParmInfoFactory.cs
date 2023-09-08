//PROJECT NAME: CSIAdmin
//CLASS NAME: GetAdpParmInfoFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class GetAdpParmInfoFactory
    {
        public IGetAdpParmInfo Create(IApplicationDB appDB)
        {
            var _GetAdpParmInfo = new GetAdpParmInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetAdpParmInfoExt = timerfactory.Create<IGetAdpParmInfo>(_GetAdpParmInfo);

            return iGetAdpParmInfoExt;
        }
    }
}
