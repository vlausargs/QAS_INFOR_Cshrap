//PROJECT NAME: Logistics
//CLASS NAME: ValidateBankCodeFormatFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateBankCodeFormatFactory
	{
		public IValidateBankCodeFormat Create(IApplicationDB appDB)
		{
			var _ValidateBankCodeFormat = new Logistics.Vendor.ValidateBankCodeFormat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateBankCodeFormatExt = timerfactory.Create<Logistics.Vendor.IValidateBankCodeFormat>(_ValidateBankCodeFormat);
			
			return iValidateBankCodeFormatExt;
		}
	}
}
