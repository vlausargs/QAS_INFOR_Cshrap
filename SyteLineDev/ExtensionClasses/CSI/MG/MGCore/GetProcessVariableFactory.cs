//PROJECT NAME: MG.MGCore
//CLASS NAME: GetProcessVariableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetProcessVariableFactory : IGetProcessVariableFactory
    {
        public IGetProcessVariable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetProcessVariable = new GetProcessVariable(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetProcessVariableExt = timerfactory.Create<MG.MGCore.IGetProcessVariable>(_GetProcessVariable);

            return iGetProcessVariableExt;
        }
    }
}
