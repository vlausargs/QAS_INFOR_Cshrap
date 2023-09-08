//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemJobCheckFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemJobCheckFactory
	{
		public IItemJobCheck Create(IApplicationDB appDB)
		{
			var _ItemJobCheck = new Material.ItemJobCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemJobCheckExt = timerfactory.Create<Material.IItemJobCheck>(_ItemJobCheck);
			
			return iItemJobCheckExt;
		}
	}
}
