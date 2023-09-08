using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IStringOfFactory
    {
        IStringOf Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}