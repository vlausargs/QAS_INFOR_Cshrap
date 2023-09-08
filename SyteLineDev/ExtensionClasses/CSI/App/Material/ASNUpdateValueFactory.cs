//PROJECT NAME: Material
//CLASS NAME: ASNUpdateValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ASNUpdateValueFactory
	{
		public IASNUpdateValue Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ASNUpdateValue = new Material.ASNUpdateValue(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iASNUpdateValueExt = timerfactory.Create<Material.IASNUpdateValue>(_ASNUpdateValue);
			
			return iASNUpdateValueExt;
		}
	}
}
