//PROJECT NAME: Material
//CLASS NAME: ActivateCatalogFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ActivateCatalogFactory
	{
		public IActivateCatalog Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ActivateCatalog = new Material.ActivateCatalog(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iActivateCatalogExt = timerfactory.Create<Material.IActivateCatalog>(_ActivateCatalog);
			
			return iActivateCatalogExt;
		}
	}
}
