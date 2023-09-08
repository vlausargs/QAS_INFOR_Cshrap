//PROJECT NAME: CSICustomer
//CLASS NAME: AddToPortalInteractionFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AddToPortalInteractionFactory
	{
		public IAddToPortalInteraction Create(IApplicationDB appDB)
		{
			var _AddToPortalInteraction = new Logistics.Customer.AddToPortalInteraction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddToPortalInteractionExt = timerfactory.Create<Logistics.Customer.IAddToPortalInteraction>(_AddToPortalInteraction);
			
			return iAddToPortalInteractionExt;
		}
	}
}
