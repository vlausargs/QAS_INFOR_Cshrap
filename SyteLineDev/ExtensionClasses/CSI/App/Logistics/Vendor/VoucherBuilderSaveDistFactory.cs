//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderSaveDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderSaveDistFactory
	{
		public IVoucherBuilderSaveDist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VoucherBuilderSaveDist = new Logistics.Vendor.VoucherBuilderSaveDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoucherBuilderSaveDistExt = timerfactory.Create<Logistics.Vendor.IVoucherBuilderSaveDist>(_VoucherBuilderSaveDist);
			
			return iVoucherBuilderSaveDistExt;
		}
	}
}
