//PROJECT NAME: MG.MGCore
//CLASS NAME: InitSessionContextFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class InitSessionContextFactory : IInitSessionContextFactory
    {
        public IInitSessionContext Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _InitSessionContext = new InitSessionContext(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInitSessionContextExt = timerfactory.Create<MG.MGCore.IInitSessionContext>(_InitSessionContext);

            return iInitSessionContextExt;
        }
    }
}
