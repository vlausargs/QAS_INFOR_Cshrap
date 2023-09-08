//PROJECT NAME: MG.MGCore
//CLASS NAME: InitSessionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class InitSessionFactory : IInitSessionFactory
    {
        public IInitSession Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _InitSession = new MG.MGCore.InitSession(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInitSessionExt = timerfactory.Create<MG.MGCore.IInitSession>(_InitSession);

            return iInitSessionExt;
        }
    }
}
