//PROJECT NAME: Logistics
//CLASS NAME: VendorGetRecurVoucherInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VendorGetRecurVoucherInfoFactory
	{
		public IVendorGetRecurVoucherInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VendorGetRecurVoucherInfo = new Logistics.Vendor.VendorGetRecurVoucherInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorGetRecurVoucherInfoExt = timerfactory.Create<Logistics.Vendor.IVendorGetRecurVoucherInfo>(_VendorGetRecurVoucherInfo);
			
			return iVendorGetRecurVoucherInfoExt;
		}
	}
}
