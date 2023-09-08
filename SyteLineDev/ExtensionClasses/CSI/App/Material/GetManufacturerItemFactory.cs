//PROJECT NAME: CSIMaterial
//CLASS NAME: GetManufacturerItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetManufacturerItemFactory
	{
		public IGetManufacturerItem Create(IApplicationDB appDB)
		{
			var _GetManufacturerItem = new Material.GetManufacturerItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetManufacturerItemExt = timerfactory.Create<Material.IGetManufacturerItem>(_GetManufacturerItem);
			
			return iGetManufacturerItemExt;
		}
	}
}
