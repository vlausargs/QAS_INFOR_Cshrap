//PROJECT NAME: Logistics
//CLASS NAME: ValidateInvSequenceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateInvSequenceFactory
	{
		public IValidateInvSequence Create(IApplicationDB appDB)
		{
			var _ValidateInvSequence = new Logistics.Customer.ValidateInvSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateInvSequenceExt = timerfactory.Create<Logistics.Customer.IValidateInvSequence>(_ValidateInvSequence);
			
			return iValidateInvSequenceExt;
		}
	}
}
