//PROJECT NAME: MG.MGCore
//CLASS NAME: FireEventFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class FireEventFactory : IFireEventFactory
    {
        public IFireEvent Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _FireEvent = new FireEvent(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iFireEventExt = timerfactory.Create<MG.MGCore.IFireEvent>(_FireEvent);

            return iFireEventExt;
        }
    }
}
