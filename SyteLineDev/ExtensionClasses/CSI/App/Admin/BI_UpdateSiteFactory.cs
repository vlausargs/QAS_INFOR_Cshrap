//PROJECT NAME: Admin
//CLASS NAME: BI_UpdateSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
    public class BI_UpdateSiteFactory
    {
        public IBI_UpdateSite Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _BI_UpdateSite = new Admin.BI_UpdateSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBI_UpdateSiteExt = timerfactory.Create<Admin.IBI_UpdateSite>(_BI_UpdateSite);

            return iBI_UpdateSiteExt;
        }
    }
}
