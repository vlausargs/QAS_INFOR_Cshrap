//PROJECT NAME: Material
//CLASS NAME: BuildAndActivateCatalogsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class BuildAndActivateCatalogsFactory
	{
		public IBuildAndActivateCatalogs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BuildAndActivateCatalogs = new Material.BuildAndActivateCatalogs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBuildAndActivateCatalogsExt = timerfactory.Create<Material.IBuildAndActivateCatalogs>(_BuildAndActivateCatalogs);
			
			return iBuildAndActivateCatalogsExt;
		}
	}
}
