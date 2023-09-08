using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Finance
{
    public interface IPeriodsGetDatesFactory
    {
        IPeriodsGetDates Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}