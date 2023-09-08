//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemInvAppvFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemInvAppvFactory
	{
		public IItemInvAppv Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _ItemInvAppv = new Material.ItemInvAppv(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemInvAppvExt = timerfactory.Create<Material.IItemInvAppv>(_ItemInvAppv);
			
			return iItemInvAppvExt;
		}
	}
}
