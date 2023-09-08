using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IPrefixOnlyFactory
    {
        IPrefixOnly Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}