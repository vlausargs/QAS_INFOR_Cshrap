//PROJECT NAME: Material
//CLASS NAME: UpdateItemCategoryItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpdateItemCategoryItemFactory
	{
		public IUpdateItemCategoryItem Create(IApplicationDB appDB)
		{
			var _UpdateItemCategoryItem = new Material.UpdateItemCategoryItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateItemCategoryItemExt = timerfactory.Create<Material.IUpdateItemCategoryItem>(_UpdateItemCategoryItem);
			
			return iUpdateItemCategoryItemExt;
		}
	}
}
