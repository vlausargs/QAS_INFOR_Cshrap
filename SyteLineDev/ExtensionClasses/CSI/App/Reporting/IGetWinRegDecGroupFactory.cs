using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Reporting
{
    public interface IGetWinRegDecGroupFactory
    {
        IGetWinRegDecGroup Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}