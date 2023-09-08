//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetBankCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetBankCodeFactory
	{
		public IAppmtGetBankCode Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtGetBankCode = new Logistics.Vendor.AppmtGetBankCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtGetBankCodeExt = timerfactory.Create<Logistics.Vendor.IAppmtGetBankCode>(_AppmtGetBankCode);
			
			return iAppmtGetBankCodeExt;
		}
	}
}
