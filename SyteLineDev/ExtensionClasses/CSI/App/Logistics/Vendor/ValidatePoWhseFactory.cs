//PROJECT NAME: Logistics
//CLASS NAME: ValidatePoWhseFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePoWhseFactory
	{
		public IValidatePoWhse Create(IApplicationDB appDB)
		{
			var _ValidatePoWhse = new Logistics.Vendor.ValidatePoWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePoWhseExt = timerfactory.Create<Logistics.Vendor.IValidatePoWhse>(_ValidatePoWhse);
			
			return iValidatePoWhseExt;
		}
	}
}
