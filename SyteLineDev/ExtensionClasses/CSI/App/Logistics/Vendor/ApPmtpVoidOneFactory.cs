//PROJECT NAME: Logistics
//CLASS NAME: ApPmtpVoidOneFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ApPmtpVoidOneFactory
	{
		public IApPmtpVoidOne Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApPmtpVoidOne = new Logistics.Vendor.ApPmtpVoidOne(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApPmtpVoidOneExt = timerfactory.Create<Logistics.Vendor.IApPmtpVoidOne>(_ApPmtpVoidOne);
			
			return iApPmtpVoidOneExt;
		}
	}
}
