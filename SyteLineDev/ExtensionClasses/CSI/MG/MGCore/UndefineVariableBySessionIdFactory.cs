//PROJECT NAME: MG.MGCore
//CLASS NAME: UndefineVariableBySessionIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class UndefineVariableBySessionIdFactory : IUndefineVariableBySessionIdFactory
    {
        public IUndefineVariableBySessionId Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _UndefineVariableBySessionId = new UndefineVariableBySessionId(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUndefineVariableBySessionIdExt = timerfactory.Create<MG.MGCore.IUndefineVariableBySessionId>(_UndefineVariableBySessionId);

            return iUndefineVariableBySessionIdExt;
        }
    }
}
