//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetNextCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetNextCheckFactory
	{
		public IAppmtGetNextCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtGetNextCheck = new Logistics.Vendor.AppmtGetNextCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtGetNextCheckExt = timerfactory.Create<Logistics.Vendor.IAppmtGetNextCheck>(_AppmtGetNextCheck);
			
			return iAppmtGetNextCheckExt;
		}
	}
}
