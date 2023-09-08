//PROJECT NAME: CSIVendor
//CLASS NAME: CheckVendorExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckVendorExistsFactory
	{
		public ICheckVendorExists Create(IApplicationDB appDB)
		{
			var _CheckVendorExists = new Logistics.Vendor.CheckVendorExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckVendorExistsExt = timerfactory.Create<Logistics.Vendor.ICheckVendorExists>(_CheckVendorExists);
			
			return iCheckVendorExistsExt;
		}
	}
}
