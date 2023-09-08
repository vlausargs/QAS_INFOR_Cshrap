using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface INotifyPublicationSubscribersFactory
    {
        INotifyPublicationSubscribers Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}