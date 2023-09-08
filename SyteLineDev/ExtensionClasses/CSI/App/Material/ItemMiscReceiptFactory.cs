//PROJECT NAME: Material
//CLASS NAME: ItemMiscReceiptFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemMiscReceiptFactory
	{
		public IItemMiscReceipt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemMiscReceipt = new Material.ItemMiscReceipt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemMiscReceiptExt = timerfactory.Create<Material.IItemMiscReceipt>(_ItemMiscReceipt);
			
			return iItemMiscReceiptExt;
		}
	}
}
