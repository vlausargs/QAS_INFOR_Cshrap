//PROJECT NAME: CSIMaterial
//CLASS NAME: GetSiteInvParmsInfoFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetSiteInvParmsInfoFactory
    {
        public IGetSiteInvParmsInfo Create(IApplicationDB appDB)
        {
            var _GetSiteInvParmsInfo = new GetSiteInvParmsInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetSiteInvParmsInfoExt = timerfactory.Create<IGetSiteInvParmsInfo>(_GetSiteInvParmsInfo);

            return iGetSiteInvParmsInfoExt;
        }
    }
}
