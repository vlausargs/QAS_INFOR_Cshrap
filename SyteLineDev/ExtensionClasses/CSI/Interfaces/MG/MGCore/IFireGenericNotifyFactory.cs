using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IFireGenericNotifyFactory
    {
        IFireGenericNotify Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}