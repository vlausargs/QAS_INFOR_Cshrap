//PROJECT NAME: CSIMaterial
//CLASS NAME: ItempriceItemValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItempriceItemValidFactory
	{
		public IItempriceItemValid Create(IApplicationDB appDB)
		{
			var _ItempriceItemValid = new Material.ItempriceItemValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItempriceItemValidExt = timerfactory.Create<Material.IItempriceItemValid>(_ItempriceItemValid);
			
			return iItempriceItemValidExt;
		}
	}
}
