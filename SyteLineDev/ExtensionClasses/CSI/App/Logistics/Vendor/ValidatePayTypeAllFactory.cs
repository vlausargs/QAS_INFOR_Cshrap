//PROJECT NAME: Logistics
//CLASS NAME: ValidatePayTypeAllFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePayTypeAllFactory
	{
		public IValidatePayTypeAll Create(IApplicationDB appDB)
		{
			var _ValidatePayTypeAll = new Logistics.Vendor.ValidatePayTypeAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePayTypeAllExt = timerfactory.Create<Logistics.Vendor.IValidatePayTypeAll>(_ValidatePayTypeAll);
			
			return iValidatePayTypeAllExt;
		}
	}
}
