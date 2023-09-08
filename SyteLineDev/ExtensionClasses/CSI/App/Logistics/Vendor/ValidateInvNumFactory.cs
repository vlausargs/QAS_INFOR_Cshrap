//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateInvNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateInvNumFactory
	{
		public IValidateInvNum Create(IApplicationDB appDB)
		{
			var _ValidateInvNum = new Logistics.Vendor.ValidateInvNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateInvNumExt = timerfactory.Create<Logistics.Vendor.IValidateInvNum>(_ValidateInvNum);
			
			return iValidateInvNumExt;
		}
	}
}
