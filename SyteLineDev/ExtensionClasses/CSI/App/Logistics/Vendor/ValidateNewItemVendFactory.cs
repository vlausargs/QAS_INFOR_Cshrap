//PROJECT NAME: Logistics
//CLASS NAME: ValidateNewItemVendFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateNewItemVendFactory
	{
		public IValidateNewItemVend Create(IApplicationDB appDB)
		{
			var _ValidateNewItemVend = new Logistics.Vendor.ValidateNewItemVend(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateNewItemVendExt = timerfactory.Create<Logistics.Vendor.IValidateNewItemVend>(_ValidateNewItemVend);
			
			return iValidateNewItemVendExt;
		}
	}
}
