//PROJECT NAME: Logistics
//CLASS NAME: WirePostVerifyPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class WirePostVerifyPrintFactory
	{
		public IWirePostVerifyPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WirePostVerifyPrint = new Logistics.Vendor.WirePostVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWirePostVerifyPrintExt = timerfactory.Create<Logistics.Vendor.IWirePostVerifyPrint>(_WirePostVerifyPrint);
			
			return iWirePostVerifyPrintExt;
		}
	}
}
