//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemlocDeleteMassFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemlocDeleteMassFactory
	{
		public IItemlocDeleteMass Create(IApplicationDB appDB)
		{
			var _ItemlocDeleteMass = new Material.ItemlocDeleteMass(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemlocDeleteMassExt = timerfactory.Create<Material.IItemlocDeleteMass>(_ItemlocDeleteMass);
			
			return iItemlocDeleteMassExt;
		}
	}
}
