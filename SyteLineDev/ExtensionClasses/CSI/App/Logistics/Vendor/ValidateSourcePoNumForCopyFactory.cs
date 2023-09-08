//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateSourcePoNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateSourcePoNumForCopyFactory
	{
		public IValidateSourcePoNumForCopy Create(IApplicationDB appDB)
		{
			var _ValidateSourcePoNumForCopy = new Logistics.Vendor.ValidateSourcePoNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSourcePoNumForCopyExt = timerfactory.Create<Logistics.Vendor.IValidateSourcePoNumForCopy>(_ValidateSourcePoNumForCopy);
			
			return iValidateSourcePoNumForCopyExt;
		}
	}
}
