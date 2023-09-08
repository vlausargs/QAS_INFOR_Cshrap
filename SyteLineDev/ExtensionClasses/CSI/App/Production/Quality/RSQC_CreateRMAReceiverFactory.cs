//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateRMAReceiverFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateRMAReceiverFactory
	{
		public IRSQC_CreateRMAReceiver Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateRMAReceiver = new Production.Quality.RSQC_CreateRMAReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateRMAReceiverExt = timerfactory.Create<Production.Quality.IRSQC_CreateRMAReceiver>(_RSQC_CreateRMAReceiver);
			
			return iRSQC_CreateRMAReceiverExt;
		}
	}
}
