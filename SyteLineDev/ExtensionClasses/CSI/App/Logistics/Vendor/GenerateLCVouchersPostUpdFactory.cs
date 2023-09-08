//PROJECT NAME: Logistics
//CLASS NAME: GenerateLCVouchersPostUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVouchersPostUpdFactory
	{
		public IGenerateLCVouchersPostUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateLCVouchersPostUpd = new Logistics.Vendor.GenerateLCVouchersPostUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateLCVouchersPostUpdExt = timerfactory.Create<Logistics.Vendor.IGenerateLCVouchersPostUpd>(_GenerateLCVouchersPostUpd);
			
			return iGenerateLCVouchersPostUpdExt;
		}
	}
}
