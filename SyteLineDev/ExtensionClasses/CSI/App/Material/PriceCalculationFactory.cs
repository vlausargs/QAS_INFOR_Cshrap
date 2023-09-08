//PROJECT NAME: Material
//CLASS NAME: PriceCalculationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PriceCalculationFactory
	{
		public IPriceCalculation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PriceCalculation = new Material.PriceCalculation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPriceCalculationExt = timerfactory.Create<Material.IPriceCalculation>(_PriceCalculation);
			
			return iPriceCalculationExt;
		}
	}
}
