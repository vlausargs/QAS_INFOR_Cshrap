//PROJECT NAME: Material
//CLASS NAME: istkrPreDeleteFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrPreDeleteFactory
	{
		public IistkrPreDelete Create(IApplicationDB appDB)
		{
			var _istkrPreDelete = new Material.istkrPreDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrPreDeleteExt = timerfactory.Create<Material.IistkrPreDelete>(_istkrPreDelete);
			
			return iistkrPreDeleteExt;
		}
	}
}
