//PROJECT NAME: Material
//CLASS NAME: ActivateAllCatalogsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ActivateAllCatalogsFactory
	{
		public IActivateAllCatalogs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ActivateAllCatalogs = new Material.ActivateAllCatalogs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iActivateAllCatalogsExt = timerfactory.Create<Material.IActivateAllCatalogs>(_ActivateAllCatalogs);
			
			return iActivateAllCatalogsExt;
		}
	}
}
