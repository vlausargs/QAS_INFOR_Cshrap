//PROJECT NAME: Logistics
//CLASS NAME: NextBuilderVoucherFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class NextBuilderVoucherFactory
	{
		public INextBuilderVoucher Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NextBuilderVoucher = new Logistics.Vendor.NextBuilderVoucher(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextBuilderVoucherExt = timerfactory.Create<Logistics.Vendor.INextBuilderVoucher>(_NextBuilderVoucher);
			
			return iNextBuilderVoucherExt;
		}
	}
}
