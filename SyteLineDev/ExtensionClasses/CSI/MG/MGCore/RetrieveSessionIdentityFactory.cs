//PROJECT NAME: MG.MGCore
//CLASS NAME: RetrieveSessionIdentityFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class RetrieveSessionIdentityFactory : IRetrieveSessionIdentityFactory
    {
        public IRetrieveSessionIdentity Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _RetrieveSessionIdentity = new RetrieveSessionIdentity(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRetrieveSessionIdentityExt = timerfactory.Create<MG.MGCore.IRetrieveSessionIdentity>(_RetrieveSessionIdentity);

            return iRetrieveSessionIdentityExt;
        }
    }
}
