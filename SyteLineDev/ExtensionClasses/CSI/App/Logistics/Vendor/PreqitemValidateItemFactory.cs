//PROJECT NAME: CSIVendor
//CLASS NAME: PreqitemValidateItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PreqitemValidateItemFactory
	{
		public IPreqitemValidateItem Create(IApplicationDB appDB)
		{
			var _PreqitemValidateItem = new Logistics.Vendor.PreqitemValidateItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreqitemValidateItemExt = timerfactory.Create<Logistics.Vendor.IPreqitemValidateItem>(_PreqitemValidateItem);
			
			return iPreqitemValidateItemExt;
		}
	}
}
