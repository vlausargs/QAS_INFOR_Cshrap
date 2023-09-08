using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetStringValueFactory
    {
        IGetStringValue Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}