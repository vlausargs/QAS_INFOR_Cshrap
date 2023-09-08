//PROJECT NAME: Material
//CLASS NAME: VendorConsignQtyAvailforItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class VendorConsignQtyAvailforItemFactory
	{
		public IVendorConsignQtyAvailforItem Create(IApplicationDB appDB)
		{
			var _VendorConsignQtyAvailforItem = new Material.VendorConsignQtyAvailforItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorConsignQtyAvailforItemExt = timerfactory.Create<Material.IVendorConsignQtyAvailforItem>(_VendorConsignQtyAvailforItem);
			
			return iVendorConsignQtyAvailforItemExt;
		}
	}
}
