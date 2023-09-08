//PROJECT NAME: Logistics
//CLASS NAME: ValidateInvLengthFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateInvLengthFactory
	{
		public IValidateInvLength Create(IApplicationDB appDB)
		{
			var _ValidateInvLength = new Logistics.Customer.ValidateInvLength(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateInvLengthExt = timerfactory.Create<Logistics.Customer.IValidateInvLength>(_ValidateInvLength);
			
			return iValidateInvLengthExt;
		}
	}
}
