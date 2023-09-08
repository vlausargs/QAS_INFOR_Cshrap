//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCcPurgeFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemCcPurgeFactory
	{
		public IItemCcPurge Create(IApplicationDB appDB)
		{
			var _ItemCcPurge = new Material.ItemCcPurge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCcPurgeExt = timerfactory.Create<Material.IItemCcPurge>(_ItemCcPurge);
			
			return iItemCcPurgeExt;
		}
	}
}
