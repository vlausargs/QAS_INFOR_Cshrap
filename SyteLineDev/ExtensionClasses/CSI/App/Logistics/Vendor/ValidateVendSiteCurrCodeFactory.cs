//PROJECT NAME: Logistics
//CLASS NAME: ValidateVendSiteCurrCodeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateVendSiteCurrCodeFactory
	{
		public IValidateVendSiteCurrCode Create(IApplicationDB appDB)
		{
			var _ValidateVendSiteCurrCode = new Logistics.Vendor.ValidateVendSiteCurrCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateVendSiteCurrCodeExt = timerfactory.Create<Logistics.Vendor.IValidateVendSiteCurrCode>(_ValidateVendSiteCurrCode);
			
			return iValidateVendSiteCurrCodeExt;
		}
	}
}
