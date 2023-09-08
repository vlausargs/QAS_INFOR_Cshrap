//PROJECT NAME: Logistics
//CLASS NAME: AppmtValidateCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtValidateCheckFactory
	{
		public IAppmtValidateCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtValidateCheck = new Logistics.Vendor.AppmtValidateCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtValidateCheckExt = timerfactory.Create<Logistics.Vendor.IAppmtValidateCheck>(_AppmtValidateCheck);
			
			return iAppmtValidateCheckExt;
		}
	}
}
