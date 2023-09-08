//PROJECT NAME: MG.MGCore
//CLASS NAME: GetVariableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetVariableFactory : IGetVariableFactory
    {
        public IGetVariable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetVariable = new GetVariable(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetVariableExt = timerfactory.Create<MG.MGCore.IGetVariable>(_GetVariable);

            return iGetVariableExt;
        }
    }
}
