//PROJECT NAME: Logistics
//CLASS NAME: PmtpckPostUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PmtpckPostUpdFactory
	{
		public IPmtpckPostUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PmtpckPostUpd = new Logistics.Customer.PmtpckPostUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckPostUpdExt = timerfactory.Create<Logistics.Customer.IPmtpckPostUpd>(_PmtpckPostUpd);
			
			return iPmtpckPostUpdExt;
		}
	}
}
