using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IMinDateFactory
    {
        IMinDate Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}