//PROJECT NAME: MG.MGCore
//CLASS NAME: DefineProcessVariableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class DefineProcessVariableFactory : IDefineProcessVariableFactory
    {
        public IDefineProcessVariable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _DefineProcessVariable = new DefineProcessVariable(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDefineProcessVariableExt = timerfactory.Create<MG.MGCore.IDefineProcessVariable>(_DefineProcessVariable);

            return iDefineProcessVariableExt;
        }
    }
}
