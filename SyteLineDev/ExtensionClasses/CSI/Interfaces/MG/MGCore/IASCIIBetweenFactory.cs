using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IASCIIBetweenFactory
    {
        IASCIIBetween Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}