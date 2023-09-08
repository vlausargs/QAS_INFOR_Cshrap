//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateCustomerReceiverFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateCustomerReceiverFactory
	{
		public IRSQC_CreateCustomerReceiver Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateCustomerReceiver = new Production.Quality.RSQC_CreateCustomerReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateCustomerReceiverExt = timerfactory.Create<Production.Quality.IRSQC_CreateCustomerReceiver>(_RSQC_CreateCustomerReceiver);
			
			return iRSQC_CreateCustomerReceiverExt;
		}
	}
}
