//PROJECT NAME: MG.MGCore
//CLASS NAME: AnticipateSessionIdentityFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class AnticipateSessionIdentityFactory : IAnticipateSessionIdentityFactory
    {
        public IAnticipateSessionIdentity Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _AnticipateSessionIdentity = new AnticipateSessionIdentity(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAnticipateSessionIdentityExt = timerfactory.Create<MG.MGCore.IAnticipateSessionIdentity>(_AnticipateSessionIdentity);

            return iAnticipateSessionIdentityExt;
        }
    }
}
