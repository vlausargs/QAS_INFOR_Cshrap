//PROJECT NAME: Logistics
//CLASS NAME: ValidatePoNumWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePoNumWarningFactory
	{
		public IValidatePoNumWarning Create(IApplicationDB appDB)
		{
			var _ValidatePoNumWarning = new Logistics.Vendor.ValidatePoNumWarning(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePoNumWarningExt = timerfactory.Create<Logistics.Vendor.IValidatePoNumWarning>(_ValidatePoNumWarning);
			
			return iValidatePoNumWarningExt;
		}
	}
}
