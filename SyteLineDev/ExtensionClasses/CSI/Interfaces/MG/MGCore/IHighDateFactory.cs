using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IHighDateFactory
    {
        IHighDate Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}