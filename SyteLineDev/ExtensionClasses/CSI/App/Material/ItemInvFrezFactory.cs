//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemInvFrezFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemInvFrezFactory
	{
		public IItemInvFrez Create(IApplicationDB appDB)
		{
			var _ItemInvFrez = new Material.ItemInvFrez(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemInvFrezExt = timerfactory.Create<Material.IItemInvFrez>(_ItemInvFrez);
			
			return iItemInvFrezExt;
		}
	}
}
