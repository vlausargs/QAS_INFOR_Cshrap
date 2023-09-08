//PROJECT NAME: Logistics
//CLASS NAME: ApPmtpOneFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ApPmtpOneFactory
	{
		public IApPmtpOne Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApPmtpOne = new Logistics.Vendor.ApPmtpOne(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApPmtpOneExt = timerfactory.Create<Logistics.Vendor.IApPmtpOne>(_ApPmtpOne);
			
			return iApPmtpOneExt;
		}
	}
}
