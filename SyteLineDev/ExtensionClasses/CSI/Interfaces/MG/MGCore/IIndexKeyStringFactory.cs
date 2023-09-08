using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIndexKeyStringFactory
    {
        IIndexKeyString Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}