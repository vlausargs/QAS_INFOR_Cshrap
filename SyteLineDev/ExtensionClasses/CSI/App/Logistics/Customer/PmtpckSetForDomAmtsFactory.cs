//PROJECT NAME: Logistics
//CLASS NAME: PmtpckSetForDomAmtsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PmtpckSetForDomAmtsFactory
	{
		public IPmtpckSetForDomAmts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PmtpckSetForDomAmts = new Logistics.Customer.PmtpckSetForDomAmts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckSetForDomAmtsExt = timerfactory.Create<Logistics.Customer.IPmtpckSetForDomAmts>(_PmtpckSetForDomAmts);
			
			return iPmtpckSetForDomAmtsExt;
		}
	}
}
