using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IWBPerGetFactory
    {
        IWBPerGet Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}