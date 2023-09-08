//PROJECT NAME: Logistics
//CLASS NAME: GetVendExchRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetVendExchRateFactory
	{
		public IGetVendExchRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetVendExchRate = new Logistics.Vendor.GetVendExchRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVendExchRateExt = timerfactory.Create<Logistics.Vendor.IGetVendExchRate>(_GetVendExchRate);
			
			return iGetVendExchRateExt;
		}
	}
}
