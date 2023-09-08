//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateItemVendFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateItemVendFactory
	{
		public IValidateItemVend Create(IApplicationDB appDB)
		{
			var _ValidateItemVend = new Logistics.Vendor.ValidateItemVend(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateItemVendExt = timerfactory.Create<Logistics.Vendor.IValidateItemVend>(_ValidateItemVend);
			
			return iValidateItemVendExt;
		}
	}
}
