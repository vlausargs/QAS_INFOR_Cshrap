//PROJECT NAME: CSIMaterial
//CLASS NAME: SelectInventoryTagsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class SelectInventoryTagsFactory
	{
		public ISelectInventoryTags Create(IApplicationDB appDB)
		{
			var _SelectInventoryTags = new Material.SelectInventoryTags(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSelectInventoryTagsExt = timerfactory.Create<Material.ISelectInventoryTags>(_SelectInventoryTags);
			
			return iSelectInventoryTagsExt;
		}
	}
}
