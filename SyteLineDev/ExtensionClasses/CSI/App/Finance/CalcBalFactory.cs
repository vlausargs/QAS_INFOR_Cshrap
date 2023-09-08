//PROJECT NAME: Finance
//CLASS NAME: CalcBalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
    public class CalcBalFactory : ICalcBalFactory
    {
        public ICalcBal Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CalcBal = new Finance.CalcBal(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCalcBalExt = timerfactory.Create<Finance.ICalcBal>(_CalcBal);

            return iCalcBalExt;
        }
    }
}
