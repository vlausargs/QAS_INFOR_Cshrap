//PROJECT NAME: Material
//CLASS NAME: istkrRecalculateCostsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrRecalculateCostsFactory
	{
		public IistkrRecalculateCosts Create(IApplicationDB appDB)
		{
			var _istkrRecalculateCosts = new Material.istkrRecalculateCosts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrRecalculateCostsExt = timerfactory.Create<Material.IistkrRecalculateCosts>(_istkrRecalculateCosts);
			
			return iistkrRecalculateCostsExt;
		}
	}
}
