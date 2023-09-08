//PROJECT NAME: CSIVendor
//CLASS NAME: ValidatePoVendNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePoVendNumFactory
	{
		public IValidatePoVendNum Create(IApplicationDB appDB)
		{
			var _ValidatePoVendNum = new Logistics.Vendor.ValidatePoVendNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePoVendNumExt = timerfactory.Create<Logistics.Vendor.IValidatePoVendNum>(_ValidatePoVendNum);
			
			return iValidatePoVendNumExt;
		}
	}
}
