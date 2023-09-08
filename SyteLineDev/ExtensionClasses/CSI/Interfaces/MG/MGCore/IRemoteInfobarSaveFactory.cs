using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IRemoteInfobarSaveFactory
    {
        IRemoteInfobarSave Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}