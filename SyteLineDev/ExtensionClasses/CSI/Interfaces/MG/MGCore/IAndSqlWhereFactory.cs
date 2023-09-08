using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IAndSqlWhereFactory
    {
        IAndSqlWhere Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}