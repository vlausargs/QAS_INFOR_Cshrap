//PROJECT NAME: CSIVendor
//CLASS NAME: ClearTTVouchersFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ClearTTVouchersFactory
	{
		public IClearTTVouchers Create(IApplicationDB appDB)
		{
			var _ClearTTVouchers = new Logistics.Vendor.ClearTTVouchers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iClearTTVouchersExt = timerfactory.Create<Logistics.Vendor.IClearTTVouchers>(_ClearTTVouchers);
			
			return iClearTTVouchersExt;
		}
	}
}
