using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDataTypeStringFactory
    {
        IDataTypeString Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}