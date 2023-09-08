using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIsValidLiteralFactory
    {
        IIsValidLiteral Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}