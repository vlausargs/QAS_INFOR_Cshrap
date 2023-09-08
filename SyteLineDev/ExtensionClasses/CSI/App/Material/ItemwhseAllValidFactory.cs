//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseAllValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemwhseAllValidFactory
	{
		public IItemwhseAllValid Create(IApplicationDB appDB)
		{
			var _ItemwhseAllValid = new Material.ItemwhseAllValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemwhseAllValidExt = timerfactory.Create<Material.IItemwhseAllValid>(_ItemwhseAllValid);
			
			return iItemwhseAllValidExt;
		}
	}
}
