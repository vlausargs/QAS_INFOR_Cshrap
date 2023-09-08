//PROJECT NAME: Material
//CLASS NAME: CalcTrnShipQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CalcTrnShipQtyFactory
	{
		public ICalcTrnShipQty Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcTrnShipQty = new Material.CalcTrnShipQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcTrnShipQtyExt = timerfactory.Create<Material.ICalcTrnShipQty>(_CalcTrnShipQty);
			
			return iCalcTrnShipQtyExt;
		}
	}
}
