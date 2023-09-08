//PROJECT NAME: CSIMaterial
//CLASS NAME: GetTransferFobSiteFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetTransferFobSiteFactory
    {
        public IGetTransferFobSite Create(IApplicationDB appDB)
        {
            var _GetTransferFobSite = new GetTransferFobSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetTransferFobSiteExt = timerfactory.Create<IGetTransferFobSite>(_GetTransferFobSite);

            return iGetTransferFobSiteExt;
        }
    }
}
