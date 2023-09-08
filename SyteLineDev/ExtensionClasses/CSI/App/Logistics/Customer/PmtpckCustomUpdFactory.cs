//PROJECT NAME: Logistics
//CLASS NAME: PmtpckCustomUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PmtpckCustomUpdFactory
	{
		public IPmtpckCustomUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PmtpckCustomUpd = new Logistics.Customer.PmtpckCustomUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckCustomUpdExt = timerfactory.Create<Logistics.Customer.IPmtpckCustomUpd>(_PmtpckCustomUpd);
			
			return iPmtpckCustomUpdExt;
		}
	}
}
