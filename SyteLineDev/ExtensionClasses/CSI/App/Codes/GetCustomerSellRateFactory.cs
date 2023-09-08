//PROJECT NAME: Codes
//CLASS NAME: GetCustomerSellRateFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetCustomerSellRateFactory
	{
		public IGetCustomerSellRate Create(IApplicationDB appDB)
		{
			var _GetCustomerSellRate = new Codes.GetCustomerSellRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustomerSellRateExt = timerfactory.Create<Codes.IGetCustomerSellRate>(_GetCustomerSellRate);
			
			return iGetCustomerSellRateExt;
		}
	}
}
