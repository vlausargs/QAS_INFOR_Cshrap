using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIndexIncludeColumnStringFactory
    {
        IIndexIncludeColumnString Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}