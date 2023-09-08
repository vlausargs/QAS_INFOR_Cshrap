//PROJECT NAME: Logistics
//CLASS NAME: IsVendorDeactivationValidAllFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class IsVendorDeactivationValidAllFactory
	{
		public IIsVendorDeactivationValidAll Create(IApplicationDB appDB)
		{
			var _IsVendorDeactivationValidAll = new Logistics.Vendor.IsVendorDeactivationValidAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsVendorDeactivationValidAllExt = timerfactory.Create<Logistics.Vendor.IIsVendorDeactivationValidAll>(_IsVendorDeactivationValidAll);
			
			return iIsVendorDeactivationValidAllExt;
		}
	}
}
