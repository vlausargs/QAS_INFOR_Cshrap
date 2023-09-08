//PROJECT NAME: CSIMaterial
//CLASS NAME: PhyinvPostFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PhyinvPostFactory
	{
		public IPhyinvPost Create(IApplicationDB appDB)
		{
			var _PhyinvPost = new Material.PhyinvPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvPostExt = timerfactory.Create<Material.IPhyinvPost>(_PhyinvPost);
			
			return iPhyinvPostExt;
		}
	}
}
