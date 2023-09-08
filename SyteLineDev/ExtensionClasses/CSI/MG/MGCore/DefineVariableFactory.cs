//PROJECT NAME: MG.MGCore
//CLASS NAME: DefineVariableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class DefineVariableFactory : IDefineVariableFactory
    {
        public IDefineVariable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _DefineVariable = new DefineVariable(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDefineVariableExt = timerfactory.Create<MG.MGCore.IDefineVariable>(_DefineVariable);

            return iDefineVariableExt;
        }
    }
}
