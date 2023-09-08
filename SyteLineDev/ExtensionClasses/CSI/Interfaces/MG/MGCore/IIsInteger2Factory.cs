using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIsInteger2Factory
    {
        IIsInteger2 Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}