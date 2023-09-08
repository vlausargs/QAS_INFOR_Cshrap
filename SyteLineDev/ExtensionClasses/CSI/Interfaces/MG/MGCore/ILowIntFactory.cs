using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ILowIntFactory
    {
        ILowInt Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}