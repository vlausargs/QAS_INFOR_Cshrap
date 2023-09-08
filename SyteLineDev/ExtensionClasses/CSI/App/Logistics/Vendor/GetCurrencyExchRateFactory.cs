//PROJECT NAME: CSIVendor
//CLASS NAME: GetCurrencyExchRateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetCurrencyExchRateFactory
	{
		public IGetCurrencyExchRate Create(IApplicationDB appDB)
		{
			var _GetCurrencyExchRate = new Logistics.Vendor.GetCurrencyExchRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCurrencyExchRateExt = timerfactory.Create<Logistics.Vendor.IGetCurrencyExchRate>(_GetCurrencyExchRate);
			
			return iGetCurrencyExchRateExt;
		}
	}
}
