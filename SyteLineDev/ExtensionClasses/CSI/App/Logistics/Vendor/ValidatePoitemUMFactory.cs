//PROJECT NAME: Logistics
//CLASS NAME: ValidatePoitemUMFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePoitemUMFactory
	{
		public IValidatePoitemUM Create(IApplicationDB appDB)
		{
			var _ValidatePoitemUM = new Logistics.Vendor.ValidatePoitemUM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePoitemUMExt = timerfactory.Create<Logistics.Vendor.IValidatePoitemUM>(_ValidatePoitemUM);
			
			return iValidatePoitemUMExt;
		}
	}
}
