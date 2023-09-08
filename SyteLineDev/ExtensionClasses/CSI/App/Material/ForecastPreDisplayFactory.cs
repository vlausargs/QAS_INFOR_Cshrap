//PROJECT NAME: CSIMaterial
//CLASS NAME: ForecastPreDisplayFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ForecastPreDisplayFactory
    {
        public IForecastPreDisplay Create(IApplicationDB appDB)
        {
            var _ForecastPreDisplay = new ForecastPreDisplay(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iForecastPreDisplayExt = timerfactory.Create<IForecastPreDisplay>(_ForecastPreDisplay);

            return iForecastPreDisplayExt;
        }
    }
}
