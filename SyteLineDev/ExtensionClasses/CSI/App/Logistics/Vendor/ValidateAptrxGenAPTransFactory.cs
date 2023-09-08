//PROJECT NAME: Logistics
//CLASS NAME: ValidateAptrxGenAPTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ValidateAptrxGenAPTransFactory
	{
		public IValidateAptrxGenAPTrans Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateAptrxGenAPTrans = new Logistics.Vendor.ValidateAptrxGenAPTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateAptrxGenAPTransExt = timerfactory.Create<Logistics.Vendor.IValidateAptrxGenAPTrans>(_ValidateAptrxGenAPTrans);
			
			return iValidateAptrxGenAPTransExt;
		}
	}
}
