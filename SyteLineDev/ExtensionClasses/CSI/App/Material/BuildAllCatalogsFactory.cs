//PROJECT NAME: Material
//CLASS NAME: BuildAllCatalogsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class BuildAllCatalogsFactory
	{
		public IBuildAllCatalogs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BuildAllCatalogs = new Material.BuildAllCatalogs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBuildAllCatalogsExt = timerfactory.Create<Material.IBuildAllCatalogs>(_BuildAllCatalogs);
			
			return iBuildAllCatalogsExt;
		}
	}
}
