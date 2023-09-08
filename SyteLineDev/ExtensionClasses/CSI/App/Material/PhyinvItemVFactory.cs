//PROJECT NAME: CSIMaterial
//CLASS NAME: PhyinvItemVFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PhyinvItemVFactory
	{
		public IPhyinvItemV Create(IApplicationDB appDB)
		{
			var _PhyinvItemV = new Material.PhyinvItemV(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvItemVExt = timerfactory.Create<Material.IPhyinvItemV>(_PhyinvItemV);
			
			return iPhyinvItemVExt;
		}
	}
}
