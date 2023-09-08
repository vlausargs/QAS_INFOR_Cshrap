//PROJECT NAME: MG.MGCore
//CLASS NAME: InitSessionContextWithUserFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class InitSessionContextWithUserFactory : IInitSessionContextWithUserFactory
    {
        public IInitSessionContextWithUser Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _InitSessionContextWithUser = new InitSessionContextWithUser(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInitSessionContextWithUserExt = timerfactory.Create<MG.MGCore.IInitSessionContextWithUser>(_InitSessionContextWithUser);

            return iInitSessionContextWithUserExt;
        }
    }
}
