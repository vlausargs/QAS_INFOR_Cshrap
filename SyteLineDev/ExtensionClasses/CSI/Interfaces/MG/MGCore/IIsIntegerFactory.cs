using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IIsIntegerFactory
    {
        IIsInteger Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}