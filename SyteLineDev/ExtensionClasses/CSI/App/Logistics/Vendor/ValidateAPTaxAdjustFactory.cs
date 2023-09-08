//PROJECT NAME: Logistics
//CLASS NAME: ValidateAPTaxAdjustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateAPTaxAdjustFactory
	{
		public IValidateAPTaxAdjust Create(IApplicationDB appDB)
		{
			var _ValidateAPTaxAdjust = new Logistics.Vendor.ValidateAPTaxAdjust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateAPTaxAdjustExt = timerfactory.Create<Logistics.Vendor.IValidateAPTaxAdjust>(_ValidateAPTaxAdjust);
			
			return iValidateAPTaxAdjustExt;
		}
	}
}
