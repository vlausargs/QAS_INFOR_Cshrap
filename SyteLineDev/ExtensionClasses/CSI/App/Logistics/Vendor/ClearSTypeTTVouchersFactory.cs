//PROJECT NAME: Logistics
//CLASS NAME: ClearSTypeTTVouchersFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ClearSTypeTTVouchersFactory
	{
		public IClearSTypeTTVouchers Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ClearSTypeTTVouchers = new Logistics.Vendor.ClearSTypeTTVouchers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iClearSTypeTTVouchersExt = timerfactory.Create<Logistics.Vendor.IClearSTypeTTVouchers>(_ClearSTypeTTVouchers);
			
			return iClearSTypeTTVouchersExt;
		}
	}
}
