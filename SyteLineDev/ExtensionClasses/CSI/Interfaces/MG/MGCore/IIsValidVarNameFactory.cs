using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIsValidVarNameFactory
    {
        IIsValidVarName Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}