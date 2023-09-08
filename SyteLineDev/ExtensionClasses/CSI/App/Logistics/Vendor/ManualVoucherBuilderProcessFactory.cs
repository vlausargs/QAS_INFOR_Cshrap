//PROJECT NAME: Logistics
//CLASS NAME: ManualVoucherBuilderProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ManualVoucherBuilderProcessFactory
	{
		public IManualVoucherBuilderProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ManualVoucherBuilderProcess = new Logistics.Vendor.ManualVoucherBuilderProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iManualVoucherBuilderProcessExt = timerfactory.Create<Logistics.Vendor.IManualVoucherBuilderProcess>(_ManualVoucherBuilderProcess);
			
			return iManualVoucherBuilderProcessExt;
		}
	}
}
