//PROJECT NAME: Logistics
//CLASS NAME: ValidateSiteSSameBaseCurrSharedVendSameCurrFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateSiteSSameBaseCurrSharedVendSameCurrFactory
	{
		public IValidateSiteSSameBaseCurrSharedVendSameCurr Create(IApplicationDB appDB)
		{
			var _ValidateSiteSSameBaseCurrSharedVendSameCurr = new Logistics.Vendor.ValidateSiteSSameBaseCurrSharedVendSameCurr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSiteSSameBaseCurrSharedVendSameCurrExt = timerfactory.Create<Logistics.Vendor.IValidateSiteSSameBaseCurrSharedVendSameCurr>(_ValidateSiteSSameBaseCurrSharedVendSameCurr);
			
			return iValidateSiteSSameBaseCurrSharedVendSameCurrExt;
		}
	}
}
