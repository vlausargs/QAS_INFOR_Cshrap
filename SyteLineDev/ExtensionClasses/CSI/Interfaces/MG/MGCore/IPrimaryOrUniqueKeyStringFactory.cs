using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IPrimaryOrUniqueKeyStringFactory
    {
        IPrimaryOrUniqueKeyString Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}