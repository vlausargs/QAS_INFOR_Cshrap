//PROJECT NAME: Logistics
//CLASS NAME: PmtpckDraftCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PmtpckDraftCheckFactory
	{
		public IPmtpckDraftCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PmtpckDraftCheck = new Logistics.Customer.PmtpckDraftCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckDraftCheckExt = timerfactory.Create<Logistics.Customer.IPmtpckDraftCheck>(_PmtpckDraftCheck);
			
			return iPmtpckDraftCheckExt;
		}
	}
}
