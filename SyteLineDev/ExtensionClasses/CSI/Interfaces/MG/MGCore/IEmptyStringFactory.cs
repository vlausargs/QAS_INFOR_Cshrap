using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IEmptyStringFactory
    {
        IEmptyString Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}