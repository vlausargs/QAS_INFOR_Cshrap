//PROJECT NAME: Logistics
//CLASS NAME: ValidateReqNumForConvertFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateReqNumForConvertFactory
	{
		public IValidateReqNumForConvert Create(IApplicationDB appDB)
		{
			var _ValidateReqNumForConvert = new Logistics.Vendor.ValidateReqNumForConvert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateReqNumForConvertExt = timerfactory.Create<Logistics.Vendor.IValidateReqNumForConvert>(_ValidateReqNumForConvert);
			
			return iValidateReqNumForConvertExt;
		}
	}
}
