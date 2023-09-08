using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetTimeByDateTimeFactory
    {
        IGetTimeByDateTime Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}