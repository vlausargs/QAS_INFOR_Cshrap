//PROJECT NAME: Material
//CLASS NAME: istkrValMrbFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrValMrbFactory
	{
		public IistkrValMrb Create(IApplicationDB appDB)
		{
			var _istkrValMrb = new Material.istkrValMrb(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrValMrbExt = timerfactory.Create<Material.IistkrValMrb>(_istkrValMrb);
			
			return iistkrValMrbExt;
		}
	}
}
