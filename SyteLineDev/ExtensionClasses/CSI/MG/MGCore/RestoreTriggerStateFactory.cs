//PROJECT NAME: MG.MGCore
//CLASS NAME: RestoreTriggerStateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class RestoreTriggerStateFactory : IRestoreTriggerStateFactory
    {
        public IRestoreTriggerState Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _RestoreTriggerState = new RestoreTriggerState(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRestoreTriggerStateExt = timerfactory.Create<MG.MGCore.IRestoreTriggerState>(_RestoreTriggerState);

            return iRestoreTriggerStateExt;
        }
    }
}
