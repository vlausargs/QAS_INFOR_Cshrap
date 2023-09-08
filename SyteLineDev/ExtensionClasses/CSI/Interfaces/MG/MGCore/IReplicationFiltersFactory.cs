using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IReplicationFiltersFactory
    {
        IReplicationFilters Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}