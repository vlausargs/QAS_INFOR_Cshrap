//PROJECT NAME: Material
//CLASS NAME: CalcUnitPrice1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CalcUnitPrice1Factory
	{
		public ICalcUnitPrice1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcUnitPrice1 = new Material.CalcUnitPrice1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcUnitPrice1Ext = timerfactory.Create<Material.ICalcUnitPrice1>(_CalcUnitPrice1);
			
			return iCalcUnitPrice1Ext;
		}
	}
}
