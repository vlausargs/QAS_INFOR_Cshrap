using CSI.Data;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IEventMessageChoicesFactory
    {
        IEventMessageChoices Create(IApplicationDB appDB, IMGInvoker mgInvoker, IBunchedLoadCollection bunchedLoadCollection, IParameterProvider parameterProvider, IDataTableUtil dataTableUtil, bool calledFromIDO);
    }
}