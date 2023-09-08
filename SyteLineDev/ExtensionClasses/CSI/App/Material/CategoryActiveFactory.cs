//PROJECT NAME: CSIMaterial
//CLASS NAME: CategoryActiveFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CategoryActiveFactory
	{
		public ICategoryActive Create(IApplicationDB appDB)
		{
			var _CategoryActive = new Material.CategoryActive(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCategoryActiveExt = timerfactory.Create<Material.ICategoryActive>(_CategoryActive);
			
			return iCategoryActiveExt;
		}
	}
}
