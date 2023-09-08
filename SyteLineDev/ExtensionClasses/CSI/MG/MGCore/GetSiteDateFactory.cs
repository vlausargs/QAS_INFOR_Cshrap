//PROJECT NAME: MGCore
//CLASS NAME: GetSiteDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetSiteDateFactory : IGetSiteDateFactory
    {
        public IGetSiteDate Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetSiteDate = new GetSiteDate(appDB);


            return _GetSiteDate;
        }
    }
}
