using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IMsgAskFactory
    {
        IMsgAsk Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}