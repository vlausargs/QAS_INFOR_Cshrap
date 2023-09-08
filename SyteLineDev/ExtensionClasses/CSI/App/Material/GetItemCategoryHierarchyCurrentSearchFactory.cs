//PROJECT NAME: CSIMaterial
//CLASS NAME: GetItemCategoryHierarchyCurrentSearchFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetItemCategoryHierarchyCurrentSearchFactory
	{
		public IGetItemCategoryHierarchyCurrentSearch Create(IApplicationDB appDB)
		{
			var _GetItemCategoryHierarchyCurrentSearch = new Material.GetItemCategoryHierarchyCurrentSearch(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemCategoryHierarchyCurrentSearchExt = timerfactory.Create<Material.IGetItemCategoryHierarchyCurrentSearch>(_GetItemCategoryHierarchyCurrentSearch);
			
			return iGetItemCategoryHierarchyCurrentSearchExt;
		}
	}
}
