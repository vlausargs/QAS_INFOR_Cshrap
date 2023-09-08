//PROJECT NAME: Material
//CLASS NAME: WhseQtyListFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class WhseQtyListFactory
	{
		public IWhseQtyList Create(IApplicationDB appDB)
		{
			var _WhseQtyList = new Material.WhseQtyList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWhseQtyListExt = timerfactory.Create<Material.IWhseQtyList>(_WhseQtyList);
			
			return iWhseQtyListExt;
		}
	}
}
