//PROJECT NAME: Logistics
//CLASS NAME: PmtpckCleanUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PmtpckCleanUpFactory
	{
		public IPmtpckCleanUp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PmtpckCleanUp = new Logistics.Customer.PmtpckCleanUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckCleanUpExt = timerfactory.Create<Logistics.Customer.IPmtpckCleanUp>(_PmtpckCleanUp);
			
			return iPmtpckCleanUpExt;
		}
	}
}
