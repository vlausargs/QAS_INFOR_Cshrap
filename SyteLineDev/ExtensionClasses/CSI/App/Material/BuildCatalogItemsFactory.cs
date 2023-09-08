//PROJECT NAME: Material
//CLASS NAME: BuildCatalogItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class BuildCatalogItemsFactory
	{
		public IBuildCatalogItems Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BuildCatalogItems = new Material.BuildCatalogItems(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBuildCatalogItemsExt = timerfactory.Create<Material.IBuildCatalogItems>(_BuildCatalogItems);
			
			return iBuildCatalogItemsExt;
		}
	}
}
