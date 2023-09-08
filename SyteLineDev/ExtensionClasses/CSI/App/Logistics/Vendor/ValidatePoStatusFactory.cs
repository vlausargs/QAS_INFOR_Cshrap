//PROJECT NAME: CSIVendor
//CLASS NAME: ValidatePoStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePoStatusFactory
	{
		public IValidatePoStatus Create(IApplicationDB appDB)
		{
			var _ValidatePoStatus = new Logistics.Vendor.ValidatePoStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePoStatusExt = timerfactory.Create<Logistics.Vendor.IValidatePoStatus>(_ValidatePoStatus);
			
			return iValidatePoStatusExt;
		}
	}
}
