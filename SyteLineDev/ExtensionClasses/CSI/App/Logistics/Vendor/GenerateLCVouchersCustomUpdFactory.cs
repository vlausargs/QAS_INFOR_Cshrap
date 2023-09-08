//PROJECT NAME: Logistics
//CLASS NAME: GenerateLCVouchersCustomUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVouchersCustomUpdFactory
	{
		public IGenerateLCVouchersCustomUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateLCVouchersCustomUpd = new Logistics.Vendor.GenerateLCVouchersCustomUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateLCVouchersCustomUpdExt = timerfactory.Create<Logistics.Vendor.IGenerateLCVouchersCustomUpd>(_GenerateLCVouchersCustomUpd);
			
			return iGenerateLCVouchersCustomUpdExt;
		}
	}
}
