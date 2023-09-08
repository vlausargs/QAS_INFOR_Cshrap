//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemMiscReceiptSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemMiscReceiptSetVarsFactory
	{
		public IItemMiscReceiptSetVars Create(IApplicationDB appDB)
		{
			var _ItemMiscReceiptSetVars = new Material.ItemMiscReceiptSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemMiscReceiptSetVarsExt = timerfactory.Create<Material.IItemMiscReceiptSetVars>(_ItemMiscReceiptSetVars);
			
			return iItemMiscReceiptSetVarsExt;
		}
	}
}
