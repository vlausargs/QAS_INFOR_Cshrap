//PROJECT NAME: Logistics
//CLASS NAME: ValidateAPVendNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ValidateAPVendNumFactory
	{
		public IValidateAPVendNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateAPVendNum = new Logistics.Vendor.ValidateAPVendNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateAPVendNumExt = timerfactory.Create<Logistics.Vendor.IValidateAPVendNum>(_ValidateAPVendNum);
			
			return iValidateAPVendNumExt;
		}
	}
}
