//PROJECT NAME: Material
//CLASS NAME: CanUpdateCostsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CanUpdateCostsFactory
	{
		public ICanUpdateCosts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CanUpdateCosts = new Material.CanUpdateCosts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCanUpdateCostsExt = timerfactory.Create<Material.ICanUpdateCosts>(_CanUpdateCosts);
			
			return iCanUpdateCostsExt;
		}
	}
}
