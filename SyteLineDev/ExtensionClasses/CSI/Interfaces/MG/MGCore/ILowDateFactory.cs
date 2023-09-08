using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ILowDateFactory
    {
        ILowDate Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}