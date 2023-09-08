//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateSupplierReceiverFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateSupplierReceiverFactory
	{
		public IRSQC_CreateSupplierReceiver Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateSupplierReceiver = new Production.Quality.RSQC_CreateSupplierReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateSupplierReceiverExt = timerfactory.Create<Production.Quality.IRSQC_CreateSupplierReceiver>(_RSQC_CreateSupplierReceiver);
			
			return iRSQC_CreateSupplierReceiverExt;
		}
	}
}
