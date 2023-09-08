using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ITimeZoneConvert2Factory
    {
        ITimeZoneConvert2 Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}