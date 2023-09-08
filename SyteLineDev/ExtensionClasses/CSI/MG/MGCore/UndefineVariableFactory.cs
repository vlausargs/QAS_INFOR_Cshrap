//PROJECT NAME: MG.MGCore
//CLASS NAME: UndefineVariableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class UndefineVariableFactory : IUndefineVariableFactory
    {
        public IUndefineVariable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _UndefineVariable = new UndefineVariable(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUndefineVariableExt = timerfactory.Create<MG.MGCore.IUndefineVariable>(_UndefineVariable);

            return iUndefineVariableExt;
        }
    }
}
