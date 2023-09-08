using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Finance
{
    public interface IPerGetFactory
    {
        IPerGet Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}