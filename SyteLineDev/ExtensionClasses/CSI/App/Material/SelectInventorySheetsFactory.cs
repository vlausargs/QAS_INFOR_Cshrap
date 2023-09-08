//PROJECT NAME: CSIMaterial
//CLASS NAME: SelectInventorySheetsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class SelectInventorySheetsFactory
	{
		public ISelectInventorySheets Create(IApplicationDB appDB)
		{
			var _SelectInventorySheets = new Material.SelectInventorySheets(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSelectInventorySheetsExt = timerfactory.Create<Material.ISelectInventorySheets>(_SelectInventorySheets);
			
			return iSelectInventorySheetsExt;
		}
	}
}
