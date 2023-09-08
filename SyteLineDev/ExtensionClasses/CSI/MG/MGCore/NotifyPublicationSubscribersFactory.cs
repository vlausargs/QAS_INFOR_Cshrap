//PROJECT NAME: MG.MGCore
//CLASS NAME: NotifyPublicationSubscribersFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class NotifyPublicationSubscribersFactory : INotifyPublicationSubscribersFactory
    {
        public INotifyPublicationSubscribers Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _NotifyPublicationSubscribers = new NotifyPublicationSubscribers(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iNotifyPublicationSubscribersExt = timerfactory.Create<MG.MGCore.INotifyPublicationSubscribers>(_NotifyPublicationSubscribers);

            return iNotifyPublicationSubscribersExt;
        }
    }
}
