using CSI.Data;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IStringLinesFactory
    {
        IStringLines Create(IApplicationDB appDB, IMGInvoker mgInvoker, IBunchedLoadCollection bunchedLoadCollection, IParameterProvider parameterProvider, IDataTableUtil dataTableUtil, bool calledFromIDO);
    }
}