//PROJECT NAME: CSICustomer
//CLASS NAME: InteractionTopicValidatorFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InteractionTopicValidatorFactory
	{
		public IInteractionTopicValidator Create(IApplicationDB appDB)
		{
			var _InteractionTopicValidator = new Logistics.Customer.InteractionTopicValidator(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInteractionTopicValidatorExt = timerfactory.Create<Logistics.Customer.IInteractionTopicValidator>(_InteractionTopicValidator);
			
			return iInteractionTopicValidatorExt;
		}
	}
}
