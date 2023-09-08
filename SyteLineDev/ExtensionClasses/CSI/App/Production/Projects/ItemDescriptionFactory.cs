//PROJECT NAME: CSIProjects
//CLASS NAME: ItemDescriptionFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ItemDescriptionFactory
	{
		public IItemDescription Create(IApplicationDB appDB)
		{
			var _ItemDescription = new Production.Projects.ItemDescription(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemDescriptionExt = timerfactory.Create<Production.Projects.IItemDescription>(_ItemDescription);
			
			return iItemDescriptionExt;
		}
	}
}
