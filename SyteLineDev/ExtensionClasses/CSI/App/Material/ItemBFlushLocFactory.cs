//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemBFlushLocFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemBFlushLocFactory
	{
		public IItemBFlushLoc Create(IApplicationDB appDB)
		{
			var _ItemBFlushLoc = new Material.ItemBFlushLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemBFlushLocExt = timerfactory.Create<Material.IItemBFlushLoc>(_ItemBFlushLoc);
			
			return iItemBFlushLocExt;
		}
	}
}
