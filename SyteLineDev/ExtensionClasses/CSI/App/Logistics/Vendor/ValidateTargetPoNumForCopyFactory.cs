//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateTargetPoNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateTargetPoNumForCopyFactory
	{
		public IValidateTargetPoNumForCopy Create(IApplicationDB appDB)
		{
			var _ValidateTargetPoNumForCopy = new Logistics.Vendor.ValidateTargetPoNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateTargetPoNumForCopyExt = timerfactory.Create<Logistics.Vendor.IValidateTargetPoNumForCopy>(_ValidateTargetPoNumForCopy);
			
			return iValidateTargetPoNumForCopyExt;
		}
	}
}
