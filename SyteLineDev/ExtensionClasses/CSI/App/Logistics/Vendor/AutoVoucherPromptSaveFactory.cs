//PROJECT NAME: Logistics
//CLASS NAME: AutoVoucherPromptSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AutoVoucherPromptSaveFactory
	{
		public IAutoVoucherPromptSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AutoVoucherPromptSave = new Logistics.Vendor.AutoVoucherPromptSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutoVoucherPromptSaveExt = timerfactory.Create<Logistics.Vendor.IAutoVoucherPromptSave>(_AutoVoucherPromptSave);
			
			return iAutoVoucherPromptSaveExt;
		}
	}
}
