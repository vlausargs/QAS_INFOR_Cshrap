//PROJECT NAME: Logistics
//CLASS NAME: UpdateExchRateInfoByCustFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class UpdateExchRateInfoByCustFactory
	{
		public IUpdateExchRateInfoByCust Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateExchRateInfoByCust = new Logistics.Customer.UpdateExchRateInfoByCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateExchRateInfoByCustExt = timerfactory.Create<Logistics.Customer.IUpdateExchRateInfoByCust>(_UpdateExchRateInfoByCust);
			
			return iUpdateExchRateInfoByCustExt;
		}
	}
}
