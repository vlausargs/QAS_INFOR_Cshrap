//PROJECT NAME: Material
//CLASS NAME: istkrValItemlocRankFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrValItemlocRankFactory
	{
		public IistkrValItemlocRank Create(IApplicationDB appDB)
		{
			var _istkrValItemlocRank = new Material.istkrValItemlocRank(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrValItemlocRankExt = timerfactory.Create<Material.IistkrValItemlocRank>(_istkrValItemlocRank);
			
			return iistkrValItemlocRankExt;
		}
	}
}
