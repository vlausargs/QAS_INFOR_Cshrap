using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IHighIntFactory
    {
        IHighInt Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}