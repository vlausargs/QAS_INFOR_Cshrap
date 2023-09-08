//PROJECT NAME: Material
//CLASS NAME: ForecastPostSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ForecastPostSaveFactory
	{
		public IForecastPostSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ForecastPostSave = new Material.ForecastPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iForecastPostSaveExt = timerfactory.Create<Material.IForecastPostSave>(_ForecastPostSave);
			
			return iForecastPostSaveExt;
		}
	}
}
