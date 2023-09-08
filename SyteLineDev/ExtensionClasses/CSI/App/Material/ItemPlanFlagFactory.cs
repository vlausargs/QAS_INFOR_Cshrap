//PROJECT NAME: Material
//CLASS NAME: ItemPlanFlagFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemPlanFlagFactory
	{
		public IItemPlanFlag Create(IApplicationDB appDB)
		{
			var _ItemPlanFlag = new Material.ItemPlanFlag(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemPlanFlagExt = timerfactory.Create<Material.IItemPlanFlag>(_ItemPlanFlag);
			
			return iItemPlanFlagExt;
		}
	}
}
