using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetErrorMessageFactory
    {
        IGetErrorMessage Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}