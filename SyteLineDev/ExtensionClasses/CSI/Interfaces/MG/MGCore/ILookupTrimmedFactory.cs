using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ILookupTrimmedFactory
    {
        ILookupTrimmed Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}