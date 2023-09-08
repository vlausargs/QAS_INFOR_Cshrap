//PROJECT NAME: MG.MGCore
//CLASS NAME: SetTriggerStateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class SetTriggerStateFactory : ISetTriggerStateFactory
    {
        public ISetTriggerState Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _SetTriggerState = new SetTriggerState(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetTriggerStateExt = timerfactory.Create<MG.MGCore.ISetTriggerState>(_SetTriggerState);

            return iSetTriggerStateExt;
        }
    }
}
