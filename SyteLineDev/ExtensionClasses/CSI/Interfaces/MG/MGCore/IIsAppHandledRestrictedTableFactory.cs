using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIsAppHandledRestrictedTableFactory
    {
        IIsAppHandledRestrictedTable Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}