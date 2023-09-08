//PROJECT NAME: CSIMaterial
//CLASS NAME: DefaultInventoryTagsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class DefaultInventoryTagsFactory
	{
		public IDefaultInventoryTags Create(IApplicationDB appDB)
		{
			var _DefaultInventoryTags = new Material.DefaultInventoryTags(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDefaultInventoryTagsExt = timerfactory.Create<Material.IDefaultInventoryTags>(_DefaultInventoryTags);
			
			return iDefaultInventoryTagsExt;
		}
	}
}
