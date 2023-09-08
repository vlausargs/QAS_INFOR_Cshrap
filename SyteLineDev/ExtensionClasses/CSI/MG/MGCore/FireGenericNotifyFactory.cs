//PROJECT NAME: MG.MGCore
//CLASS NAME: FireGenericNotifyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class FireGenericNotifyFactory : IFireGenericNotifyFactory
    {
        public IFireGenericNotify Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _FireGenericNotify = new FireGenericNotify(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iFireGenericNotifyExt = timerfactory.Create<MG.MGCore.IFireGenericNotify>(_FireGenericNotify);

            return iFireGenericNotifyExt;
        }
    }
}
