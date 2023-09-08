//PROJECT NAME: MG.MGCore
//CLASS NAME: CopySessionVariablesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CopySessionVariablesFactory : ICopySessionVariablesFactory
    {
        public ICopySessionVariables Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CopySessionVariables = new CopySessionVariables(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCopySessionVariablesExt = timerfactory.Create<MG.MGCore.ICopySessionVariables>(_CopySessionVariables);

            return iCopySessionVariablesExt;
        }
    }
}
