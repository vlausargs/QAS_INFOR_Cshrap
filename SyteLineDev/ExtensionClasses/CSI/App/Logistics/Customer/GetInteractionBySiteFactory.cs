//PROJECT NAME: CSICustomer
//CLASS NAME: GetInteractionBySiteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetInteractionBySiteFactory
	{
		public IGetInteractionBySite Create(IApplicationDB appDB)
		{
			var _GetInteractionBySite = new Logistics.Customer.GetInteractionBySite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInteractionBySiteExt = timerfactory.Create<Logistics.Customer.IGetInteractionBySite>(_GetInteractionBySite);
			
			return iGetInteractionBySiteExt;
		}
	}
}
