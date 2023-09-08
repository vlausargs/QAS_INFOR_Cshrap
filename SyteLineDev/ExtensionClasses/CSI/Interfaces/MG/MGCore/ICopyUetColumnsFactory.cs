using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICopyUetColumnsFactory
    {
        ICopyUetColumns Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}