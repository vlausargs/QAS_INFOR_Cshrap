//PROJECT NAME: CSICustomer
//CLASS NAME: GetProspectsInteractionCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetProspectsInteractionCountFactory
	{
		public IGetProspectsInteractionCount Create(IApplicationDB appDB)
		{
			var _GetProspectsInteractionCount = new Logistics.Customer.GetProspectsInteractionCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProspectsInteractionCountExt = timerfactory.Create<Logistics.Customer.IGetProspectsInteractionCount>(_GetProspectsInteractionCount);
			
			return iGetProspectsInteractionCountExt;
		}
	}
}
