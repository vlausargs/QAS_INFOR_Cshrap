//PROJECT NAME: CSIMaterial
//CLASS NAME: ForecastDateCalcFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ForecastDateCalcFactory
    {
        public IForecastDateCalc Create(IApplicationDB appDB)
        {
            var _ForecastDateCalc = new ForecastDateCalc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iForecastDateCalcExt = timerfactory.Create<IForecastDateCalc>(_ForecastDateCalc);

            return iForecastDateCalcExt;
        }
    }
}
