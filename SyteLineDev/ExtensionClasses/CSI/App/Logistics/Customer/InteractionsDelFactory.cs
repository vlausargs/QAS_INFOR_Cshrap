//PROJECT NAME: CSICustomer
//CLASS NAME: InteractionsDelFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InteractionsDelFactory
	{
		public IInteractionsDel Create(IApplicationDB appDB)
		{
			var _InteractionsDel = new Logistics.Customer.InteractionsDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInteractionsDelExt = timerfactory.Create<Logistics.Customer.IInteractionsDel>(_InteractionsDel);
			
			return iInteractionsDelExt;
		}
	}
}
