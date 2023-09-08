//PROJECT NAME: Logistics
//CLASS NAME: APVchPostingVerifyPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class APVchPostingVerifyPrintFactory
	{
		public IAPVchPostingVerifyPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _APVchPostingVerifyPrint = new Logistics.Vendor.APVchPostingVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPVchPostingVerifyPrintExt = timerfactory.Create<Logistics.Vendor.IAPVchPostingVerifyPrint>(_APVchPostingVerifyPrint);
			
			return iAPVchPostingVerifyPrintExt;
		}
	}
}
