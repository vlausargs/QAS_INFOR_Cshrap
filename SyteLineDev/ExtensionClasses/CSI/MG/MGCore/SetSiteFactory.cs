//PROJECT NAME: MG.MGCore
//CLASS NAME: SetSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class SetSiteFactory : ISetSiteFactory
    {
        public ISetSite Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _SetSite = new MGSetSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetSiteExt = timerfactory.Create<MG.MGCore.ISetSite>(_SetSite);

            return iSetSiteExt;
        }
    }
}
