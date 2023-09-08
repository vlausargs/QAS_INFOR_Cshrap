//PROJECT NAME: MG.MGCore
//CLASS NAME: DefineVariableBySessionIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class DefineVariableBySessionIdFactory : IDefineVariableBySessionIdFactory
    {
        public IDefineVariableBySessionId Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _DefineVariableBySessionId = new DefineVariableBySessionId(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDefineVariableBySessionIdExt = timerfactory.Create<MG.MGCore.IDefineVariableBySessionId>(_DefineVariableBySessionId);

            return iDefineVariableBySessionIdExt;
        }
    }
}
