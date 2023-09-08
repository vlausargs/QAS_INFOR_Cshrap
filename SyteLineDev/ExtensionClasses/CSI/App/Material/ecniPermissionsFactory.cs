//PROJECT NAME: Material
//CLASS NAME: ecniPermissionsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ecniPermissionsFactory
	{
		public IecniPermissions Create(IApplicationDB appDB)
		{
			var _ecniPermissions = new Material.ecniPermissions(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iecniPermissionsExt = timerfactory.Create<Material.IecniPermissions>(_ecniPermissions);
			
			return iecniPermissionsExt;
		}
	}
}
