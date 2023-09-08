using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ISitePartitionSchemeExistsFactory
    {
        ISitePartitionSchemeExists Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}