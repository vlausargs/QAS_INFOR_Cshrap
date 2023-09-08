//PROJECT NAME: Material
//CLASS NAME: ForecastCalcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ForecastCalcFactory
	{
		public IForecastCalc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ForecastCalc = new Material.ForecastCalc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iForecastCalcExt = timerfactory.Create<Material.IForecastCalc>(_ForecastCalc);
			
			return iForecastCalcExt;
		}
	}
}
