//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemPreDisplayEntryFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemPreDisplayEntryFactory
	{
		public IItemPreDisplayEntry Create(IApplicationDB appDB)
		{
			var _ItemPreDisplayEntry = new Material.ItemPreDisplayEntry(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemPreDisplayEntryExt = timerfactory.Create<Material.IItemPreDisplayEntry>(_ItemPreDisplayEntry);
			
			return iItemPreDisplayEntryExt;
		}
	}
}
