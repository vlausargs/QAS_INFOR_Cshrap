//PROJECT NAME: Material
//CLASS NAME: UpdateItemCategoryHierarchyFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpdateItemCategoryHierarchyFactory
	{
		public IUpdateItemCategoryHierarchy Create(IApplicationDB appDB)
		{
			var _UpdateItemCategoryHierarchy = new Material.UpdateItemCategoryHierarchy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateItemCategoryHierarchyExt = timerfactory.Create<Material.IUpdateItemCategoryHierarchy>(_UpdateItemCategoryHierarchy);
			
			return iUpdateItemCategoryHierarchyExt;
		}
	}
}
